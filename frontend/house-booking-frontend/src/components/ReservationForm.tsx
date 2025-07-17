import { useState } from 'react';
import type { Property, CreateReservationRequest } from '../types';
import { reservationService } from '../services/api';

interface ReservationFormProps {
  property: Property;
  onClose: () => void;
  onReservationCreated: () => void;
}

const ReservationForm = ({ property, onClose, onReservationCreated }: ReservationFormProps) => {
  const [formData, setFormData] = useState({
    checkInDate: '',
    checkOutDate: '',
    numberOfGuests: 1,
    specialRequests: ''
  });
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const handleChange = (e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement | HTMLSelectElement>) => {
    const { name, value } = e.target;
    setFormData(prev => ({
      ...prev,
      [name]: name === 'numberOfGuests' ? parseInt(value) : value
    }));
  };

  const calculateTotalAmount = () => {
    if (!formData.checkInDate || !formData.checkOutDate) return 0;
    
    const checkIn = new Date(formData.checkInDate);
    const checkOut = new Date(formData.checkOutDate);
    const nights = Math.ceil((checkOut.getTime() - checkIn.getTime()) / (1000 * 60 * 60 * 24));
    
    return nights > 0 ? nights * parseFloat(property.pricePerNight.replace(/[^0-9.]/g, '')) : 0;
  };

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    setLoading(true);
    setError(null);

    try {
      const reservationRequest: CreateReservationRequest = {
        propertyId: property.id,
        guestId: 'temp-user-id', // In a real app, this would come from authentication
        checkInDate: formData.checkInDate,
        checkOutDate: formData.checkOutDate,
        numberOfGuests: formData.numberOfGuests,
        specialRequests: formData.specialRequests || undefined
      };

      await reservationService.createReservation(reservationRequest);
      onReservationCreated();
      onClose();
    } catch (error: any) {
      setError(error.response?.data?.message || 'An error occurred while creating the reservation');
    } finally {
      setLoading(false);
    }
  };

  const totalAmount = calculateTotalAmount();
  const nights = formData.checkInDate && formData.checkOutDate
    ? Math.ceil((new Date(formData.checkOutDate).getTime() - new Date(formData.checkInDate).getTime()) / (1000 * 60 * 60 * 24))
    : 0;

  return (
    <div className="reservation-form-overlay">
      <div className="reservation-form">
        <div className="form-header">
          <h2>Complete your reservation</h2>
          <button className="close-btn" onClick={onClose}>×</button>
        </div>
        
        <div className="property-summary">
          <div className="property-image">
            <img src={property.imageUrl || '/placeholder-property.jpg'} alt={property.name} />
          </div>
          <div className="property-details">
            <h3>{property.name}</h3>
            <p className="property-location">📍 {property.location}</p>
            <p className="property-type">{property.propertyType}</p>
            <div className="property-rating">
              <span className="rating-star">★</span>
              <span>{property.rating}</span>
              <span>({property.reviewCount} reviews)</span>
            </div>
          </div>
        </div>
        
        <form onSubmit={handleSubmit}>
          {error && <div className="error-message">{error}</div>}
          
          <div className="form-section">
            <h4>Your trip</h4>
            <div className="form-row">
              <div className="form-group">
                <label htmlFor="checkInDate">Check-in</label>
                <input
                  type="date"
                  id="checkInDate"
                  name="checkInDate"
                  value={formData.checkInDate}
                  onChange={handleChange}
                  required
                  min={new Date().toISOString().split('T')[0]}
                />
              </div>

              <div className="form-group">
                <label htmlFor="checkOutDate">Check-out</label>
                <input
                  type="date"
                  id="checkOutDate"
                  name="checkOutDate"
                  value={formData.checkOutDate}
                  onChange={handleChange}
                  required
                  min={formData.checkInDate || new Date().toISOString().split('T')[0]}
                />
              </div>
            </div>

            <div className="form-group">
              <label htmlFor="numberOfGuests">Number of guests</label>
              <select
                id="numberOfGuests"
                name="numberOfGuests"
                value={formData.numberOfGuests}
                onChange={handleChange}
                required
              >
                {[1, 2, 3, 4, 5, 6, 7, 8].map(num => (
                  <option key={num} value={num}>{num} guest{num > 1 ? 's' : ''}</option>
                ))}
              </select>
            </div>
          </div>

          <div className="form-section">
            <h4>Special requests</h4>
            <div className="form-group">
              <label htmlFor="specialRequests">Any special requests? (Optional)</label>
              <textarea
                id="specialRequests"
                name="specialRequests"
                value={formData.specialRequests}
                onChange={handleChange}
                rows={3}
                placeholder="Let us know if you have any special requests..."
              />
            </div>
          </div>

          {nights > 0 && (
            <div className="pricing-summary">
              <h4>Price breakdown</h4>
              <div className="price-row">
                <span>{property.pricePerNight} × {nights} nights</span>
                <span>${totalAmount.toFixed(2)}</span>
              </div>
              <div className="price-row total">
                <span>Total</span>
                <span>${totalAmount.toFixed(2)}</span>
              </div>
            </div>
          )}

          <div className="form-actions">
            <button type="button" onClick={onClose} className="cancel-btn">
              Cancel
            </button>
            <button type="submit" disabled={loading || totalAmount === 0} className="confirm-btn">
              {loading ? 'Processing...' : `Confirm Reservation - $${totalAmount.toFixed(2)}`}
            </button>
          </div>
        </form>
      </div>
    </div>
  );
};

export default ReservationForm;