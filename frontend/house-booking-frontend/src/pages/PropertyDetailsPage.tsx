import React, { useState, useEffect } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import { propertyService } from '../services/api';

interface Property {
  id: string;
  name: string;
  description: string;
  propertyType: {
    name: string;
    description: string;
  };
  location: {
    city: string;
    country: string;
    address: string;
  };
  isActive: boolean;
  ownerId: string;
}

const PropertyDetailsPage: React.FC = () => {
  const { id } = useParams<{ id: string }>();
  const navigate = useNavigate();
  const [property, setProperty] = useState<Property | null>(null);
  const [loading, setLoading] = useState(true);
  const [isEditing, setIsEditing] = useState(false);
  const [editForm, setEditForm] = useState({
    name: '',
    description: '',
    propertyType: '',
    city: '',
    country: '',
    address: ''
  });

  useEffect(() => {
    if (id) {
      fetchProperty();
    }
  }, [id]);

  const fetchProperty = async () => {
    try {
      setLoading(true);
      const response = await propertyService.getPropertyById(id!);
      setProperty(response);
      setEditForm({
        name: response.name,
        description: response.description,
        propertyType: response.propertyType.name,
        city: response.location.city,
        country: response.location.country,
        address: response.location.address || ''
      });
    } catch (error) {
      console.error('Error fetching property:', error);
    } finally {
      setLoading(false);
    }
  };

  const handleSave = async () => {
    try {
      await propertyService.updateProperty(id!, {
        name: editForm.name,
        description: editForm.description,
        propertyType: {
          name: editForm.propertyType,
          description: '',
          category: 'Hotel'
        },
        location: {
          city: editForm.city,
          country: editForm.country,
          address: editForm.address,
          postalCode: '',
          geoLocation: {}
        }
      });
      setIsEditing(false);
      fetchProperty();
    } catch (error) {
      console.error('Error updating property:', error);
    }
  };

  const handleToggleActive = async () => {
    if (!property) return;
    
    try {
      if (property.isActive) {
        await propertyService.deactivateProperty(id!);
      } else {
        await propertyService.activateProperty(id!);
      }
      fetchProperty();
    } catch (error) {
      console.error('Error toggling property status:', error);
    }
  };

  if (loading) {
    return <div className="loading">Loading property details...</div>;
  }

  if (!property) {
    return <div className="error">Property not found</div>;
  }

  return (
    <div className="property-details-page">
      <div className="page-header">
        <button 
          className="btn btn-outline"
          onClick={() => navigate('/properties')}
        >
          ← Back to Properties
        </button>
        <h1>Property Details</h1>
        <div className="header-actions">
          {!isEditing ? (
            <button 
              className="btn btn-primary"
              onClick={() => setIsEditing(true)}
            >
              ✏️ Edit
            </button>
          ) : (
            <div className="edit-actions">
              <button 
                className="btn btn-outline"
                onClick={() => setIsEditing(false)}
              >
                Cancel
              </button>
              <button 
                className="btn btn-success"
                onClick={handleSave}
              >
                💾 Save
              </button>
            </div>
          )}
        </div>
      </div>

      <div className="property-content">
        <div className="property-info-card">
          <div className="property-header">
            <div className="property-title">
              {isEditing ? (
                <input
                  type="text"
                  value={editForm.name}
                  onChange={(e) => setEditForm({...editForm, name: e.target.value})}
                  className="edit-input title-input"
                />
              ) : (
                <h2>{property.name}</h2>
              )}
            </div>
            <div className={`status ${property.isActive ? 'active' : 'inactive'}`}>
              {property.isActive ? '🟢 Active' : '🔴 Inactive'}
            </div>
          </div>

          <div className="property-details">
            <div className="detail-group">
              <label>Description:</label>
              {isEditing ? (
                <textarea
                  value={editForm.description}
                  onChange={(e) => setEditForm({...editForm, description: e.target.value})}
                  className="edit-textarea"
                  rows={4}
                />
              ) : (
                <p>{property.description}</p>
              )}
            </div>

            <div className="detail-group">
              <label>Property Type:</label>
              {isEditing ? (
                <input
                  type="text"
                  value={editForm.propertyType}
                  onChange={(e) => setEditForm({...editForm, propertyType: e.target.value})}
                  className="edit-input"
                />
              ) : (
                <p>🏢 {property.propertyType.name}</p>
              )}
            </div>

            <div className="detail-group">
              <label>Location:</label>
              {isEditing ? (
                <div className="location-inputs">
                  <input
                    type="text"
                    placeholder="City"
                    value={editForm.city}
                    onChange={(e) => setEditForm({...editForm, city: e.target.value})}
                    className="edit-input"
                  />
                  <input
                    type="text"
                    placeholder="Country"
                    value={editForm.country}
                    onChange={(e) => setEditForm({...editForm, country: e.target.value})}
                    className="edit-input"
                  />
                  <input
                    type="text"
                    placeholder="Address"
                    value={editForm.address}
                    onChange={(e) => setEditForm({...editForm, address: e.target.value})}
                    className="edit-input"
                  />
                </div>
              ) : (
                <p>📍 {property.location.city}, {property.location.country}</p>
              )}
            </div>
          </div>

          <div className="property-actions">
            <button 
              className="btn btn-outline"
              onClick={() => navigate(`/properties/${id}/rooms`)}
            >
              🛏️ Manage Rooms
            </button>
            <button 
              className="btn btn-outline"
              onClick={() => navigate(`/properties/${id}/reviews`)}
            >
              ⭐ View Reviews
            </button>
            <button 
              className="btn btn-outline"
              onClick={() => navigate(`/properties/${id}/images`)}
            >
              🖼️ Manage Images
            </button>
            <button 
              className={`btn ${property.isActive ? 'btn-warning' : 'btn-success'}`}
              onClick={handleToggleActive}
            >
              {property.isActive ? '❌ Deactivate' : '✅ Activate'}
            </button>
          </div>
        </div>
      </div>
    </div>
  );
};

export default PropertyDetailsPage;