import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import { propertyService } from '../services/api';
import { MapContainer, TileLayer, Marker, Popup } from 'react-leaflet';
import L from 'leaflet';
import 'leaflet/dist/leaflet.css';

// Create a custom icon for the map markers
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
  imageUrl: string;
  location: {
    city: string;
    country: string;
    address?: string;
    postalCode?: string;
    geoLocation?: {
      latitude: number;
      longitude: number;
    };
  };
  rating: number;
  reviewCount: number;
  isActive: boolean;
  createdAt: string;
  updatedAt: string;
}

const AirbnbHomePage: React.FC = () => {
  const [properties, setProperties] = useState<Property[]>([]);
  const [loading, setLoading] = useState(true);
  const [searchLocation, setSearchLocation] = useState('');
  const [checkIn, setCheckIn] = useState('');
  const [checkOut, setCheckOut] = useState('');
  const [guests, setGuests] = useState(1);
  const [selectedProperty, setSelectedProperty] = useState<Property | null>(null);
  const [mapCenter, setMapCenter] = useState<[number, number]>([41.0082, 28.9784]); // Istanbul default
  const [mapZoom, setMapZoom] = useState(10);
  const navigate = useNavigate();

  useEffect(() => {
    fetchProperties();
  }, []);

  const fetchProperties = async () => {
    try {
      setLoading(true);
      const response = await propertyService.getProperties({
        pageNumber: 1,
        pageSize: 20,
        isActive: true
      });
      
      const propertiesData = response.properties || response.items || response || [];
      setProperties(propertiesData);
    } catch (error) {
      console.error('Error fetching properties:', error);
    } finally {
      setLoading(false);
    }
  };

  const handleSearch = async () => {
    try {
      setLoading(true);
      const response = await propertyService.getProperties({
        pageNumber: 1,
        pageSize: 20,
        searchTerm: searchLocation || undefined,
        city: searchLocation || undefined
      });
      
      const propertiesData = response.properties || response.items || response || [];
      setProperties(propertiesData);
    } catch (error) {
      console.error('Error searching properties:', error);
    } finally {
      setLoading(false);
    }
  };

  const handlePropertyClick = (propertyId: string) => {
    const property = properties.find(p => p.id === propertyId);
    if (property) {
      setSelectedProperty(property);
      if (property.location.geoLocation?.latitude && property.location.geoLocation?.longitude) {
        setMapCenter([property.location.geoLocation.latitude, property.location.geoLocation.longitude]);
        setMapZoom(15);
      }
    }
  };

  const handleViewDetails = (propertyId: string) => {
    navigate(`/property/${propertyId}`);
  };

  const renderStars = (rating: number) => {
    return '★'.repeat(Math.floor(rating)) + '☆'.repeat(5 - Math.floor(rating));
  };

  return (
    <div className="airbnb-home">
      {/* Header */}
      <header className="airbnb-header">
        <div className="header-content">
          <div className="logo">
            <h1>🏠 StayBooking</h1>
          </div>
          <nav className="nav-links">
            <a href="#" onClick={() => navigate('/properties')}>Properties</a>
            <a href="#" onClick={() => navigate('/rooms')}>Rooms</a>
          </nav>
        </div>
      </header>

      {/* Hero Section */}
      <section className="hero">
        <div className="hero-content">
          <h2>Find your next stay</h2>
          <p>Search low prices on hotels, homes and much more...</p>
        </div>
      </section>

      {/* Search Bar */}
      <div className="search-section">
        <div className="search-bar">
          <div className="search-field">
            <label>Where</label>
            <input
              type="text"
              placeholder="Search destinations"
              value={searchLocation}
              onChange={(e) => setSearchLocation(e.target.value)}
            />
          </div>
          <div className="search-field">
            <label>Check in</label>
            <input
              type="date"
              value={checkIn}
              onChange={(e) => setCheckIn(e.target.value)}
            />
          </div>
          <div className="search-field">
            <label>Check out</label>
            <input
              type="date"
              value={checkOut}
              onChange={(e) => setCheckOut(e.target.value)}
            />
          </div>
          <div className="search-field">
            <label>Who</label>
            <select value={guests} onChange={(e) => setGuests(parseInt(e.target.value))}>
              <option value={1}>1 guest</option>
              <option value={2}>2 guests</option>
              <option value={3}>3 guests</option>
              <option value={4}>4 guests</option>
              <option value={5}>5+ guests</option>
            </select>
          </div>
          <button className="search-btn" onClick={handleSearch}>
            🔍 Search
          </button>
        </div>
      </div>

      {/* Properties Grid with Map */}
      <div className="properties-container">
        {loading ? (
          <div className="loading-spinner">
            <div className="spinner"></div>
            <p>Finding amazing places to stay...</p>
          </div>
        ) : (
          <div className="properties-content">
            <div className="properties-list">
              <div className="results-header">
                <h2>Places to stay</h2>
                <p>{properties.length} properties found</p>
                {properties.length === 0 && (
                  <div className="no-properties-message">
                    <p>No properties available. Please make sure:</p>
                    <ul>
                      <li>Backend server is running on https://localhost:7253</li>
                      <li>Database has been seeded with properties</li>
                      <li>CORS is configured properly</li>
                    </ul>
                  </div>
                )}
              </div>
              
              <div className="properties-grid">
                {properties.map((property) => (
                  <div
                    key={property.id}
                    className={`property-card ${selectedProperty?.id === property.id ? 'selected' : ''}`}
                    onClick={() => handlePropertyClick(property.id)}
                  >
                    <div className="property-image">
                      <img
                        src={property.imageUrl || 'data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iNDAwIiBoZWlnaHQ9IjMwMCIgdmlld0JveD0iMCAwIDQwMCAzMDAiIGZpbGw9Im5vbmUiIHhtbG5zPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2ZyI+CjxyZWN0IHdpZHRoPSI0MDAiIGhlaWdodD0iMzAwIiBmaWxsPSIjRjBGMEYwIi8+CjxyZWN0IHg9IjE1MCIgeT0iMTAwIiB3aWR0aD0iMTAwIiBoZWlnaHQ9IjEwMCIgcng9IjgiIGZpbGw9IiNEMEQwRDAiLz4KPGNpcmNsZSBjeD0iMTcwIiBjeT0iMTIwIiByPSI4IiBmaWxsPSIjQTBBMEEwIi8+CjxwYXRoIGQ9Ik0xNjAgMTQwTDE4MCAxNjBMMjAwIDE0MEwyMzAgMTcwSDE2MFYxNDBaIiBmaWxsPSIjQTBBMEEwIi8+Cjx0ZXh0IHg9IjIwMCIgeT0iMjIwIiB0ZXh0LWFuY2hvcj0ibWlkZGxlIiBmaWxsPSIjODA4MDgwIiBmb250LWZhbWlseT0iQXJpYWwsIHNhbnMtc2VyaWYiIGZvbnQtc2l6ZT0iMTYiPk5vIEltYWdlPC90ZXh0Pgo8L3N2Zz4K'}
                        alt={property.name}
                        onError={(e) => {
                          const target = e.target as HTMLImageElement;
                          target.src = 'data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iNDAwIiBoZWlnaHQ9IjMwMCIgdmlld0JveD0iMCAwIDQwMCAzMDAiIGZpbGw9Im5vbmUiIHhtbG5zPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2ZyI+CjxyZWN0IHdpZHRoPSI0MDAiIGhlaWdodD0iMzAwIiBmaWxsPSIjRjBGMEYwIi8+CjxyZWN0IHg9IjE1MCIgeT0iMTAwIiB3aWR0aD0iMTAwIiBoZWlnaHQ9IjEwMCIgcng9IjgiIGZpbGw9IiNEMEQwRDAiLz4KPGNpcmNsZSBjeD0iMTcwIiBjeT0iMTIwIiByPSI4IiBmaWxsPSIjQTBBMEEwIi8+CjxwYXRoIGQ9Ik0xNjAgMTQwTDE4MCAxNjBMMjAwIDE0MEwyMzAgMTcwSDE2MFYxNDBaIiBmaWxsPSIjQTBBMEEwIi8+Cjx0ZXh0IHg9IjIwMCIgeT0iMjIwIiB0ZXh0LWFuY2hvcj0ibWlkZGxlIiBmaWxsPSIjODA4MDgwIiBmb250LWZhbWlseT0iQXJpYWwsIHNhbnMtc2VyaWYiIGZvbnQtc2l6ZT0iMTYiPk5vIEltYWdlPC90ZXh0Pgo8L3N2Zz4K';
                        }}
                      />
                      <div className="property-heart">
                        <span>🤍</span>
                      </div>
                    </div>
                    <div className="property-info">
                      <div className="property-location">
                        <h3>{property.name}</h3>
                        <p>{property.location.city}, {property.location.country}</p>
                      </div>
                      <div className="property-rating">
                        <span className="stars">{renderStars(property.rating)}</span>
                        <span className="rating-number">{property.rating}</span>
                        <span className="review-count">({property.reviewCount} reviews)</span>
                      </div>
                      <div className="property-price">
                        <span className="price">$99</span>
                        <span className="period">night</span>
                      </div>
                    </div>
                    <div className="property-actions">
                      <button 
                        className="btn btn-primary"
                        onClick={(e) => {
                          e.stopPropagation();
                          handleViewDetails(property.id);
                        }}
                      >
                        View Details
                      </button>
                    </div>
                  </div>
                ))}
              </div>
            </div>

            {/* Map Container */}
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
                        position={[property.location.geoLocation!.latitude, property.location.geoLocation!.longitude]}
                        icon={customIcon}
                        eventHandlers={{
                          click: () => handlePropertyClick(property.id),
                        }}
                      >
                        <Popup>
                          <div className="map-popup">
                            <h4>{property.name}</h4>
                            <p>{property.description}</p>
                            <p><strong>📍 {property.location.city}, {property.location.country}</strong></p>
                            <p>⭐ {property.rating} ({property.reviewCount} reviews)</p>
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
        )}
      </div>

      {/* Footer */}
      <footer className="airbnb-footer">
        <div className="footer-content">
          <div className="footer-section">
            <h4>Support</h4>
            <ul>
              <li><a href="#">Help Center</a></li>
              <li><a href="#">Safety information</a></li>
              <li><a href="#">Cancellation options</a></li>
            </ul>
          </div>
          <div className="footer-section">
            <h4>Community</h4>
            <ul>
              <li><a href="#">Airbnb.org: disaster relief housing</a></li>
              <li><a href="#">Combating discrimination</a></li>
            </ul>
          </div>
          <div className="footer-section">
            <h4>Hosting</h4>
            <ul>
              <li><a href="#">Airbnb your home</a></li>
              <li><a href="#">AirCover for Hosts</a></li>
              <li><a href="#">Hosting resources</a></li>
            </ul>
          </div>
        </div>
        <div className="footer-bottom">
          <p>© 2024 StayBooking, Inc. All rights reserved.</p>
        </div>
      </footer>
    </div>
  );
};

export default AirbnbHomePage;