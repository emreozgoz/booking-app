import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import { propertyService } from '../services/api';
import { MapContainer, TileLayer, Marker, Popup } from 'react-leaflet';
import L from 'leaflet';
import 'leaflet/dist/leaflet.css';

// Create a custom icon to fix the marker issue
const customIcon = new L.Icon({
  iconUrl: 'data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iMjQiIGhlaWdodD0iMzQiIHZpZXdCb3g9IjAgMCAyNCAzNCIgZmlsbD0ibm9uZSIgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIj4KPHBhdGggZD0iTTEyIDM0TDEyIDM0QzEyIDM0IDIyIDIyIDIyIDEyQzIyIDUuMzcyNTggMTcuNjI3NCAxIDEyIDFDNi4zNzI1OCAxIDIgNS4zNzI1OCAyIDEyQzIgMjIgMTIgMzQgMTIgMzRaIiBmaWxsPSIjRkY2QjZCIiBzdHJva2U9IiNGRkZGRkYiIHN0cm9rZS13aWR0aD0iMiIvPgo8Y2lyY2xlIGN4PSIxMiIgY3k9IjEyIiByPSI0IiBmaWxsPSIjRkZGRkZGIi8+Cjwvc3ZnPgo=',
  iconSize: [24, 34],
  iconAnchor: [12, 34],
  popupAnchor: [0, -34],
  shadowUrl: 'data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iMzYiIGhlaWdodD0iMzYiIHZpZXdCb3g9IjAgMCAzNiAzNiIgZmlsbD0ibm9uZSIgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIj4KPGVsbGlwc2UgY3g9IjE4IiBjeT0iMzQiIHJ4PSIxOCIgcnk9IjIiIGZpbGw9IiMwMDAwMDAiIGZpbGwtb3BhY2l0eT0iMC4yIi8+Cjwvc3ZnPgo=',
  shadowSize: [36, 36],
  shadowAnchor: [18, 34]
});

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
    postalCode: string;
    geoLocation: {
      latitude: number;
      longitude: number;
    };
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
  const [selectedProperty, setSelectedProperty] = useState<Property | null>(null);
  const [mapCenter, setMapCenter] = useState<[number, number]>([41.0082, 28.9784]); // Istanbul default
  const [mapZoom, setMapZoom] = useState(10);
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

  const handlePropertyClick = (property: Property) => {
    setSelectedProperty(property);
    if (property.location.geoLocation.latitude && property.location.geoLocation.longitude) {
      setMapCenter([property.location.geoLocation.latitude, property.location.geoLocation.longitude]);
      setMapZoom(15);
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

      <div className="properties-content">
        <div className="properties-list">
          {loading ? (
            <div className="loading">Loading properties...</div>
          ) : (
            <div className="properties-grid">
              {properties.map((property) => (
                <div 
                  key={property.id} 
                  className={`property-card ${selectedProperty?.id === property.id ? 'selected' : ''}`}
                  onClick={() => handlePropertyClick(property)}
                >
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

                  <div className="property-actions" onClick={(e) => e.stopPropagation()}>
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

        <div className="map-container">
          <div className="map-header">
            <h3>🗺️ Properties Map</h3>
            <div className="map-info">
              <span>Selected: {selectedProperty?.name || 'None'}</span>
              <span>Properties with coordinates: {properties.filter(p => p.location.geoLocation?.latitude && p.location.geoLocation?.longitude).length}</span>
            </div>
          </div>
          <div className="map-content">
            <MapContainer
              center={mapCenter}
              zoom={mapZoom}
              scrollWheelZoom={true}
              className="leaflet-map"
              key={`${mapCenter[0]}-${mapCenter[1]}-${mapZoom}`}
            >
              <TileLayer
                attribution='&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
                url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"
              />
              {properties
                .filter(p => p.location.geoLocation?.latitude && p.location.geoLocation?.longitude)
                .map((property) => (
                  <Marker
                    key={property.id}
                    position={[property.location.geoLocation.latitude, property.location.geoLocation.longitude]}
                    icon={customIcon}
                    eventHandlers={{
                      click: () => handlePropertyClick(property),
                    }}
                  >
                    <Popup>
                      <div className="map-popup">
                        <h4>{property.name}</h4>
                        <p>{property.description}</p>
                        <p><strong>📍 {property.location.city}, {property.location.country}</strong></p>
                        <p>🏢 {property.propertyType.name}</p>
                        <div className="popup-actions">
                          <button 
                            className="btn btn-sm btn-primary"
                            onClick={() => handleViewDetails(property.id)}
                          >
                            View Details
                          </button>
                        </div>
                      </div>
                    </Popup>
                  </Marker>
                ))}
            </MapContainer>
          </div>
        </div>
      </div>
    </div>
  );
};

export default PropertiesPage;