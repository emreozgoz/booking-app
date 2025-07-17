import { useState, useEffect } from 'react';
import type { Property } from '../types';
import { propertyService } from '../services/api';
import PropertyCard from './PropertyCard';

interface PropertyListProps {
  onBookNow: (property: Property) => void;
}

const PropertyList = ({ onBookNow }: PropertyListProps) => {
  const [properties, setProperties] = useState<Property[]>([]);
  const [loading, setLoading] = useState(true);
  const [searchTerm, setSearchTerm] = useState('');
  const [location, setLocation] = useState('');
  const [checkIn, setCheckIn] = useState('');
  const [checkOut, setCheckOut] = useState('');
  const [guests, setGuests] = useState(1);

  useEffect(() => {
    fetchProperties();
  }, []);

  const fetchProperties = async () => {
    try {
      setLoading(true);
      const data = await propertyService.getProperties({
        searchTerm,
        location,
        checkInDate: checkIn,
        checkOutDate: checkOut,
        numberOfGuests: guests,
        pageNumber: 1,
        pageSize: 20
      });
      setProperties(data);
    } catch (error) {
      console.error('Error fetching properties:', error);
    } finally {
      setLoading(false);
    }
  };

  const handleSearch = (e: React.FormEvent) => {
    e.preventDefault();
    fetchProperties();
  };

  const handleReset = () => {
    setSearchTerm('');
    setLocation('');
    setCheckIn('');
    setCheckOut('');
    setGuests(1);
  };

  if (loading) {
    return (
      <div className="loading-container">
        <div className="loading-spinner"></div>
        <p>Finding amazing places to stay...</p>
      </div>
    );
  }

  return (
    <div className="property-list">
      <div className="search-hero">
        <h1>Find Your Perfect Stay</h1>
        <p>Discover unique places to stay around the world</p>
        
        <form onSubmit={handleSearch} className="search-form">
          <div className="search-row">
            <div className="search-field">
              <label htmlFor="location">Where</label>
              <input
                type="text"
                id="location"
                placeholder="Search destinations"
                value={location}
                onChange={(e) => setLocation(e.target.value)}
                className="search-input"
              />
            </div>
            
            <div className="search-field">
              <label htmlFor="checkIn">Check-in</label>
              <input
                type="date"
                id="checkIn"
                value={checkIn}
                onChange={(e) => setCheckIn(e.target.value)}
                className="search-input"
                min={new Date().toISOString().split('T')[0]}
              />
            </div>
            
            <div className="search-field">
              <label htmlFor="checkOut">Check-out</label>
              <input
                type="date"
                id="checkOut"
                value={checkOut}
                onChange={(e) => setCheckOut(e.target.value)}
                className="search-input"
                min={checkIn || new Date().toISOString().split('T')[0]}
              />
            </div>
            
            <div className="search-field">
              <label htmlFor="guests">Guests</label>
              <select
                id="guests"
                value={guests}
                onChange={(e) => setGuests(Number(e.target.value))}
                className="search-input"
              >
                {[1, 2, 3, 4, 5, 6, 7, 8].map(num => (
                  <option key={num} value={num}>{num} guest{num > 1 ? 's' : ''}</option>
                ))}
              </select>
            </div>
          </div>
          
          <div className="search-actions">
            <button type="button" onClick={handleReset} className="reset-btn">
              Reset
            </button>
            <button type="submit" className="search-btn">
              Search
            </button>
          </div>
        </form>
      </div>
      
      <div className="properties-section">
        <div className="properties-header">
          <h2>Available Properties</h2>
          <p>{properties.length} properties found</p>
        </div>
        
        <div className="properties-grid">
          {properties.length === 0 ? (
            <div className="no-properties">
              <div className="no-properties-icon">🏠</div>
              <h3>No properties found</h3>
              <p>Try adjusting your search criteria or explore different locations</p>
            </div>
          ) : (
            properties.map((property) => (
              <PropertyCard key={property.id} property={property} onBookNow={onBookNow} />
            ))
          )}
        </div>
      </div>
    </div>
  );
};

export default PropertyList;