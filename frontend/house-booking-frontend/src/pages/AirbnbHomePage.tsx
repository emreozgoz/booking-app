import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import { propertyService } from '../services/api';

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
  const navigate = useNavigate();

  useEffect(() => {
    fetchProperties();
  }, []);

  const fetchProperties = async () => {
    try {
      setLoading(true);
      console.log('Fetching properties...');
      
      const response = await propertyService.getProperties({
        pageNumber: 1,
        pageSize: 20,
        isActive: true
      });
      
      console.log('API Response:', response);
      console.log('Properties received:', response.items || response || []);
      
      // Handle different response formats
      const propertiesData = response.properties || response.items || response || [];
      setProperties(propertiesData);
      
    } catch (error: any) {
      console.error('Error fetching properties:', error);
      console.error('Error details:', error.response?.data || error.message);
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
        isActive: true,
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
          <div className="header-actions">
            <button className="host-btn">Become a Host</button>
            <button className="profile-btn">👤</button>
          </div>
        </div>
      </header>

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

      {/* Properties Grid */}
      <div className="properties-container">
        {loading ? (
          <div className="loading-spinner">
            <div className="spinner"></div>
            <p>Finding amazing places to stay...</p>
          </div>
        ) : (
          <>
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
                  className="property-card"
                  onClick={() => handlePropertyClick(property.id)}
                >
                  <div className="property-image">
                    <img
                      src={property.imageUrl || 'https://via.placeholder.com/400x300?text=No+Image'}
                      alt={property.name}
                      onError={(e) => {
                        e.currentTarget.src = 'https://via.placeholder.com/400x300?text=No+Image';
                      }}
                    />
                    <div className="property-heart">
                      <span>🤍</span>
                    </div>
                  </div>
                  
                  <div className="property-info">
                    <div className="property-header">
                      <h3>{property.name}</h3>
                      <div className="property-rating">
                        <span className="stars">{renderStars(property.rating)}</span>
                        <span className="rating-text">{property.rating}</span>
                        <span className="review-count">({property.reviewCount} reviews)</span>
                      </div>
                    </div>
                    
                    <div className="property-location">
                      <span>📍 {property.location.city}, {property.location.country}</span>
                    </div>
                    
                    <div className="property-description">
                      <p>{property.description}</p>
                    </div>
                    
                    <div className="property-price">
                      <span className="price">$99</span>
                      <span className="period">night</span>
                    </div>
                  </div>
                </div>
              ))}
            </div>
          </>
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