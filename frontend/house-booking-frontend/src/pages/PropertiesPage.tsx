import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
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
  };
  isActive: boolean;
  ownerId: string;
}

const PropertiesPage: React.FC = () => {
  const [properties, setProperties] = useState<Property[]>([]);
  const [loading, setLoading] = useState(true);
  const [searchTerm, setSearchTerm] = useState('');
  const [filters, setFilters] = useState({
    city: '',
    country: '',
    propertyType: '',
    isActive: true
  });
  const navigate = useNavigate();

  useEffect(() => {
    fetchProperties();
  }, [filters, searchTerm]);

  const fetchProperties = async () => {
    try {
      setLoading(true);
      const params = {
        pageNumber: 1,
        pageSize: 20,
        searchTerm: searchTerm || undefined,
        city: filters.city || undefined,
        country: filters.country || undefined,
        propertyType: filters.propertyType || undefined,
        isActive: filters.isActive
      };

      const response = await propertyService.getProperties(params);
      setProperties(response.items || []);
    } catch (error) {
      console.error('Error fetching properties:', error);
    } finally {
      setLoading(false);
    }
  };

  const handleViewDetails = (propertyId: string) => {
    navigate(`/properties/${propertyId}`);
  };

  const handleViewRooms = (propertyId: string) => {
    navigate(`/properties/${propertyId}/rooms`);
  };

  const handleViewReviews = (propertyId: string) => {
    navigate(`/properties/${propertyId}/reviews`);
  };

  const handleToggleActive = async (propertyId: string, isActive: boolean) => {
    try {
      if (isActive) {
        await propertyService.deactivateProperty(propertyId);
      } else {
        await propertyService.activateProperty(propertyId);
      }
      fetchProperties();
    } catch (error) {
      console.error('Error toggling property status:', error);
    }
  };

  return (
    <div className="properties-page">
      <div className="page-header">
        <h1>🏨 Properties Management</h1>
        <button 
          className="btn btn-primary"
          onClick={() => navigate('/properties/new')}
        >
          ➕ Add New Property
        </button>
      </div>

      <div className="filters-section">
        <div className="search-bar">
          <input
            type="text"
            placeholder="Search properties..."
            value={searchTerm}
            onChange={(e) => setSearchTerm(e.target.value)}
            className="search-input"
          />
        </div>
        
        <div className="filters">
          <input
            type="text"
            placeholder="City"
            value={filters.city}
            onChange={(e) => setFilters({...filters, city: e.target.value})}
            className="filter-input"
          />
          <input
            type="text"
            placeholder="Country"
            value={filters.country}
            onChange={(e) => setFilters({...filters, country: e.target.value})}
            className="filter-input"
          />
          <input
            type="text"
            placeholder="Property Type"
            value={filters.propertyType}
            onChange={(e) => setFilters({...filters, propertyType: e.target.value})}
            className="filter-input"
          />
          <select
            value={filters.isActive.toString()}
            onChange={(e) => setFilters({...filters, isActive: e.target.value === 'true'})}
            className="filter-select"
          >
            <option value="true">Active</option>
            <option value="false">Inactive</option>
          </select>
        </div>
      </div>

      {loading ? (
        <div className="loading">Loading properties...</div>
      ) : (
        <div className="properties-grid">
          {properties.map((property) => (
            <div key={property.id} className="property-card">
              <div className="property-header">
                <h3>{property.name}</h3>
                <div className={`status ${property.isActive ? 'active' : 'inactive'}`}>
                  {property.isActive ? '🟢 Active' : '🔴 Inactive'}
                </div>
              </div>
              
              <div className="property-details">
                <p className="description">{property.description}</p>
                <div className="property-info">
                  <span className="property-type">
                    🏢 {property.propertyType.name}
                  </span>
                  <span className="location">
                    📍 {property.location.city}, {property.location.country}
                  </span>
                </div>
              </div>

              <div className="property-actions">
                <button 
                  className="btn btn-outline"
                  onClick={() => handleViewDetails(property.id)}
                >
                  👁️ View Details
                </button>
                <button 
                  className="btn btn-outline"
                  onClick={() => handleViewRooms(property.id)}
                >
                  🛏️ Rooms
                </button>
                <button 
                  className="btn btn-outline"
                  onClick={() => handleViewReviews(property.id)}
                >
                  ⭐ Reviews
                </button>
                <button 
                  className={`btn ${property.isActive ? 'btn-warning' : 'btn-success'}`}
                  onClick={() => handleToggleActive(property.id, property.isActive)}
                >
                  {property.isActive ? '❌ Deactivate' : '✅ Activate'}
                </button>
              </div>
            </div>
          ))}
        </div>
      )}

      {!loading && properties.length === 0 && (
        <div className="no-results">
          <p>No properties found matching your criteria.</p>
        </div>
      )}
    </div>
  );
};

export default PropertiesPage;