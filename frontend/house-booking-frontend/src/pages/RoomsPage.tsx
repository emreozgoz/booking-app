import React, { useState, useEffect } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import { api } from '../services/api';

interface Room {
  id: string;
  type: {
    name: string;
    description: string;
  };
  capacity: number;
  price: {
    amount: number;
    currency: string;
  };
  isRefundable: boolean;
  propertyId: string;
}

const RoomsPage: React.FC = () => {
  const { propertyId } = useParams<{ propertyId: string }>();
  const navigate = useNavigate();
  const [rooms, setRooms] = useState<Room[]>([]);
  const [loading, setLoading] = useState(true);
  const [selectedRoom, setSelectedRoom] = useState<Room | null>(null);
  const [isEditing, setIsEditing] = useState(false);
  const [editForm, setEditForm] = useState({
    type: '',
    capacity: 1,
    price: 0,
    currency: 'USD',
    isRefundable: false
  });

  useEffect(() => {
    if (propertyId) {
      fetchRooms();
    }
  }, [propertyId]);

  const fetchRooms = async () => {
    try {
      setLoading(true);
      const response = await api.get(`/rooms?propertyId=${propertyId}&pageSize=50`);
      setRooms(response.data.items || []);
    } catch (error) {
      console.error('Error fetching rooms:', error);
    } finally {
      setLoading(false);
    }
  };

  const handleEditRoom = (room: Room) => {
    setSelectedRoom(room);
    setEditForm({
      type: room.type.name,
      capacity: room.capacity,
      price: room.price.amount,
      currency: room.price.currency,
      isRefundable: room.isRefundable
    });
    setIsEditing(true);
  };

  const handleSaveRoom = async () => {
    if (!selectedRoom) return;

    try {
      await api.put(`/rooms/${selectedRoom.id}/info`, {
        type: {
          name: editForm.type,
          description: '',
          capacity: editForm.capacity
        },
        capacity: editForm.capacity,
        price: {
          amount: editForm.price,
          currency: editForm.currency
        },
        isRefundable: editForm.isRefundable
      });
      setIsEditing(false);
      setSelectedRoom(null);
      fetchRooms();
    } catch (error) {
      console.error('Error updating room:', error);
    }
  };

  const handleSetAvailability = async (roomId: string, date: string, isAvailable: boolean) => {
    try {
      await api.post(`/rooms/${roomId}/availability`, {
        date: new Date(date).toISOString(),
        isAvailable
      });
      console.log('Availability updated successfully');
    } catch (error) {
      console.error('Error setting availability:', error);
    }
  };

  const handleSetPriceOverride = async (roomId: string, date: string, price: number) => {
    try {
      await api.post(`/rooms/${roomId}/price-override`, {
        date: new Date(date).toISOString(),
        price: {
          amount: price,
          currency: 'USD'
        }
      });
      console.log('Price override set successfully');
    } catch (error) {
      console.error('Error setting price override:', error);
    }
  };

  return (
    <div className="rooms-page">
      <div className="page-header">
        <button 
          className="btn btn-outline"
          onClick={() => navigate(`/properties/${propertyId}`)}
        >
          ← Back to Property
        </button>
        <h1>🛏️ Rooms Management</h1>
      </div>

      {loading ? (
        <div className="loading">Loading rooms...</div>
      ) : (
        <div className="rooms-grid">
          {rooms.map((room) => (
            <div key={room.id} className="room-card">
              <div className="room-header">
                <h3>{room.type.name}</h3>
                <div className="room-price">
                  {room.price.amount} {room.price.currency}
                </div>
              </div>
              
              <div className="room-details">
                <div className="room-info">
                  <span className="capacity">
                    👥 Capacity: {room.capacity}
                  </span>
                  <span className={`refundable ${room.isRefundable ? 'yes' : 'no'}`}>
                    {room.isRefundable ? '✅ Refundable' : '❌ Non-refundable'}
                  </span>
                </div>
              </div>

              <div className="room-actions">
                <button 
                  className="btn btn-outline"
                  onClick={() => handleEditRoom(room)}
                >
                  ✏️ Edit Info
                </button>
                <button 
                  className="btn btn-outline"
                  onClick={() => navigate(`/rooms/${room.id}/availability`)}
                >
                  📅 Availability
                </button>
                <button 
                  className="btn btn-outline"
                  onClick={() => navigate(`/rooms/${room.id}/pricing`)}
                >
                  💰 Pricing
                </button>
              </div>
            </div>
          ))}
        </div>
      )}

      {!loading && rooms.length === 0 && (
        <div className="no-results">
          <p>No rooms found for this property.</p>
        </div>
      )}

      {isEditing && selectedRoom && (
        <div className="modal-overlay">
          <div className="modal">
            <div className="modal-header">
              <h2>Edit Room Information</h2>
              <button 
                className="btn btn-text"
                onClick={() => setIsEditing(false)}
              >
                ✕
              </button>
            </div>
            
            <div className="modal-content">
              <div className="form-group">
                <label>Room Type:</label>
                <input
                  type="text"
                  value={editForm.type}
                  onChange={(e) => setEditForm({...editForm, type: e.target.value})}
                  className="form-input"
                />
              </div>

              <div className="form-group">
                <label>Capacity:</label>
                <input
                  type="number"
                  value={editForm.capacity}
                  onChange={(e) => setEditForm({...editForm, capacity: parseInt(e.target.value)})}
                  className="form-input"
                  min="1"
                />
              </div>

              <div className="form-group">
                <label>Price:</label>
                <div className="price-input-group">
                  <input
                    type="number"
                    value={editForm.price}
                    onChange={(e) => setEditForm({...editForm, price: parseFloat(e.target.value)})}
                    className="form-input"
                    min="0"
                    step="0.01"
                  />
                  <select
                    value={editForm.currency}
                    onChange={(e) => setEditForm({...editForm, currency: e.target.value})}
                    className="form-select"
                  >
                    <option value="USD">USD</option>
                    <option value="EUR">EUR</option>
                    <option value="GBP">GBP</option>
                    <option value="TRY">TRY</option>
                  </select>
                </div>
              </div>

              <div className="form-group">
                <label className="checkbox-label">
                  <input
                    type="checkbox"
                    checked={editForm.isRefundable}
                    onChange={(e) => setEditForm({...editForm, isRefundable: e.target.checked})}
                  />
                  Refundable
                </label>
              </div>
            </div>

            <div className="modal-actions">
              <button 
                className="btn btn-outline"
                onClick={() => setIsEditing(false)}
              >
                Cancel
              </button>
              <button 
                className="btn btn-success"
                onClick={handleSaveRoom}
              >
                💾 Save Changes
              </button>
            </div>
          </div>
        </div>
      )}
    </div>
  );
};

export default RoomsPage;