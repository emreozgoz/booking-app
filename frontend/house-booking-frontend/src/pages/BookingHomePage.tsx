import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import { propertyService } from '../services/api';
import { useAuth } from '../contexts/AuthContext';
import { MapContainer, TileLayer, Marker, Popup } from 'react-leaflet';
import L from 'leaflet';
import 'leaflet/dist/leaflet.css';
import '../styles/booking.css';

const customIcon = new L.Icon({
  iconUrl: 'data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iMjQiIGhlaWdodD0iMzQiIHZpZXdCb3g9IjAgMCAyNCAzNCIgZmlsbD0ibm9uZSIgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIj4KPHBhdGggZD0iTTEyIDM0TDEyIDM0QzEyIDM0IDIyIDIyIDIyIDEyQzIyIDUuMzcyNTggMTcuNjI3NCAxIDEyIDFDNi4zNzI1OCAxIDIgNS4zNzI1OCAyIDEyQzIgMjIgMTIgMzQgMTIgMzRaIiBmaWxsPSIjMDA2NkNDIiBzdHJva2U9IiNGRkZGRkYiIHN0cm9rZS13aWR0aD0iMiIvPgo8Y2lyY2xlIGN4PSIxMiIgY3k9IjEyIiByPSI0IiBmaWxsPSIjRkZGRkZGIi8+Cjwvc3ZnPgo=',
  iconSize: [24, 34],
  iconAnchor: [12, 34],
  popupAnchor: [0, -34],
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

const BookingHomePage: React.FC = () => {
  const { user, logout } = useAuth();
  const [properties, setProperties] = useState<Property[]>([]);
  const [loading, setLoading] = useState(true);
  const [searchLocation, setSearchLocation] = useState('');
  const [checkIn, setCheckIn] = useState('');
  const [checkOut, setCheckOut] = useState('');
  const [guests, setGuests] = useState(1);
  const [selectedProperty, setSelectedProperty] = useState<Property | null>(null);
  const [mapCenter, setMapCenter] = useState<[number, number]>([41.0082, 28.9784]);
  const [mapZoom, setMapZoom] = useState(10);
  const [sortBy, setSortBy] = useState('recommended');
  const [priceMin, setPriceMin] = useState('');
  const [priceMax, setPriceMax] = useState('');
  const [filters, setFilters] = useState({
    freeWifi: false,
    freeParking: false,
    pool: false,
    gym: false,
    petFriendly: false,
    airConditioning: false,
  });
  const navigate = useNavigate();

  const handleLogout = () => {
    logout();
  };

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
    const stars = [];
    const fullStars = Math.floor(rating);
    const hasHalfStar = rating % 1 !== 0;

    for (let i = 0; i < fullStars; i++) {
      stars.push('★');
    }
    if (hasHalfStar) {
      stars.push('☆');
    }
    for (let i = stars.length; i < 5; i++) {
      stars.push('☆');
    }
    
    return stars.join('');
  };

  const filteredAndSortedProperties = properties.filter(property => {
    // Apply price filters if set
    // Note: We don't have price data in the current property model, so this is placeholder
    return true;
  }).sort((a, b) => {
    switch (sortBy) {
      case 'price-low':
        return 99 - 99; // Placeholder since we don't have price data
      case 'price-high':
        return 99 - 99; // Placeholder since we don't have price data
      case 'rating':
        return b.rating - a.rating;
      case 'newest':
        return new Date(b.createdAt).getTime() - new Date(a.createdAt).getTime();
      default:
        return 0; // Recommended
    }
  });

  return (
    <div className="booking-app">
      {/* Header */}
      <header className="booking-header">
        <div className="header-container">
          <a href="/" className="logo">
            <div className="logo-icon">🏨</div>
            <span>StayBooking</span>
          </a>
          
          <nav className="header-nav">
            <a href="#" className="nav-link">Konaklama</a>
            <a href="#" className="nav-link">Uçak</a>
            <a href="#" className="nav-link">Araç Kiralama</a>
            <a href="#" className="nav-link">Turlar</a>
          </nav>
          
          <div className="header-actions">
            {user ? (
              <div style={{ display: 'flex', alignItems: 'center', gap: '16px' }}>
                <span style={{ color: 'var(--text-dark)', fontSize: '14px' }}>
                  Hoş geldiniz, <strong>{user.firstName}</strong>
                </span>
                <button className="btn btn-outline" onClick={handleLogout}>
                  Çıkış Yap
                </button>
              </div>
            ) : (
              <>
                <button className="btn btn-outline" onClick={() => navigate('/login')}>
                  Giriş Yap
                </button>
                <button className="btn btn-primary" onClick={() => navigate('/register')}>
                  Üye Ol
                </button>
              </>
            )}
          </div>
        </div>
      </header>

      {/* Hero Section */}
      <section className="hero-section">
        <div className="hero-container">
          <h1 className="hero-title">Mükemmel Konaklamanı Bul</h1>
          <p className="hero-subtitle">Milyonlarca otel, apart ve konaklama seçeneği arasından seçim yap</p>
        </div>
      </section>

      {/* Search Section */}
      <section className="search-section">
        <div className="search-container">
          <div className="search-box">
            <div className="search-field">
              <label className="search-label">Nereye gidiyorsun?</label>
              <input
                type="text"
                className="search-input"
                placeholder="Şehir, bölge veya otel adı"
                value={searchLocation}
                onChange={(e) => setSearchLocation(e.target.value)}
              />
            </div>
            
            <div className="search-field">
              <label className="search-label">Giriş Tarihi</label>
              <input
                type="date"
                className="search-input"
                value={checkIn}
                onChange={(e) => setCheckIn(e.target.value)}
              />
            </div>
            
            <div className="search-field">
              <label className="search-label">Çıkış Tarihi</label>
              <input
                type="date"
                className="search-input"
                value={checkOut}
                onChange={(e) => setCheckOut(e.target.value)}
              />
            </div>
            
            <div className="search-field">
              <label className="search-label">Misafir</label>
              <select 
                className="search-input" 
                value={guests} 
                onChange={(e) => setGuests(parseInt(e.target.value))}
              >
                <option value={1}>1 Misafir</option>
                <option value={2}>2 Misafir</option>
                <option value={3}>3 Misafir</option>
                <option value={4}>4 Misafir</option>
                <option value={5}>5+ Misafir</option>
              </select>
            </div>
            
            <button className="search-btn" onClick={handleSearch}>
              <span>🔍</span>
              Ara
            </button>
          </div>
        </div>
      </section>

      {/* Main Content */}
      <div className="main-content">
        {/* Filters Sidebar */}
        <aside className="filters-sidebar">
          <h3 className="filters-title">Filtreler</h3>
          
          {/* Price Filter */}
          <div className="filter-group">
            <h4 className="filter-group-title">Fiyat Aralığı</h4>
            <div className="price-range">
              <input
                type="number"
                className="price-input"
                placeholder="Min"
                value={priceMin}
                onChange={(e) => setPriceMin(e.target.value)}
              />
              <span>-</span>
              <input
                type="number"
                className="price-input"
                placeholder="Max"
                value={priceMax}
                onChange={(e) => setPriceMax(e.target.value)}
              />
            </div>
          </div>

          {/* Amenities Filter */}
          <div className="filter-group">
            <h4 className="filter-group-title">Olanaklar</h4>
            <div className="checkbox-group">
              <div className="checkbox-item">
                <input
                  type="checkbox"
                  id="wifi"
                  checked={filters.freeWifi}
                  onChange={(e) => setFilters({...filters, freeWifi: e.target.checked})}
                />
                <label htmlFor="wifi">Ücretsiz WiFi</label>
              </div>
              <div className="checkbox-item">
                <input
                  type="checkbox"
                  id="parking"
                  checked={filters.freeParking}
                  onChange={(e) => setFilters({...filters, freeParking: e.target.checked})}
                />
                <label htmlFor="parking">Ücretsiz Otopark</label>
              </div>
              <div className="checkbox-item">
                <input
                  type="checkbox"
                  id="pool"
                  checked={filters.pool}
                  onChange={(e) => setFilters({...filters, pool: e.target.checked})}
                />
                <label htmlFor="pool">Yüzme Havuzu</label>
              </div>
              <div className="checkbox-item">
                <input
                  type="checkbox"
                  id="gym"
                  checked={filters.gym}
                  onChange={(e) => setFilters({...filters, gym: e.target.checked})}
                />
                <label htmlFor="gym">Fitness Center</label>
              </div>
              <div className="checkbox-item">
                <input
                  type="checkbox"
                  id="ac"
                  checked={filters.airConditioning}
                  onChange={(e) => setFilters({...filters, airConditioning: e.target.checked})}
                />
                <label htmlFor="ac">Klima</label>
              </div>
              <div className="checkbox-item">
                <input
                  type="checkbox"
                  id="pet"
                  checked={filters.petFriendly}
                  onChange={(e) => setFilters({...filters, petFriendly: e.target.checked})}
                />
                <label htmlFor="pet">Evcil Hayvan Dostu</label>
              </div>
            </div>
          </div>
        </aside>

        {/* Properties Section */}
        <main className="properties-section">
          <div className="properties-header">
            <div className="results-info">
              <h2>{searchLocation ? `${searchLocation} bölgesinde konaklama` : 'Tüm Konaklama Seçenekleri'}</h2>
              <p className="results-count">{filteredAndSortedProperties.length} konaklama bulundu</p>
            </div>
            
            <div className="sort-dropdown">
              <label>Sırala:</label>
              <select 
                className="sort-select" 
                value={sortBy} 
                onChange={(e) => setSortBy(e.target.value)}
              >
                <option value="recommended">Önerilen</option>
                <option value="price-low">Fiyat (Düşük)</option>
                <option value="price-high">Fiyat (Yüksek)</option>
                <option value="rating">Puan</option>
                <option value="newest">En Yeni</option>
              </select>
            </div>
          </div>

          {loading ? (
            <div className="loading-spinner">
              <div className="spinner"></div>
              <p className="loading-text">Konaklama seçenekleri aranıyor...</p>
            </div>
          ) : filteredAndSortedProperties.length === 0 ? (
            <div className="empty-state">
              <div className="empty-icon">🏨</div>
              <h3 className="empty-title">Konaklama bulunamadı</h3>
              <p className="empty-subtitle">Arama kriterlerinizi değiştirmeyi deneyin</p>
              <button className="btn btn-primary" onClick={fetchProperties}>
                Tümünü Göster
              </button>
            </div>
          ) : (
            <div className="properties-grid">
              {filteredAndSortedProperties.map((property) => (
                <div
                  key={property.id}
                  className="property-card"
                  onClick={() => handlePropertyClick(property.id)}
                >
                  <div className="property-content">
                    <div className="property-image">
                      <img
                        src={property.imageUrl || 'data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iMjgwIiBoZWlnaHQ9IjIwMCIgdmlld0JveD0iMCAwIDI4MCAyMDAiIGZpbGw9Im5vbmUiIHhtbG5zPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2ZyI+CjxyZWN0IHdpZHRoPSIyODAiIGhlaWdodD0iMjAwIiBmaWxsPSIjRjBGMEYwIi8+CjxyZWN0IHg9IjkwIiB5PSI1MCIgd2lkdGg9IjEwMCIgaGVpZ2h0PSIxMDAiIHJ4PSI4IiBmaWxsPSIjRDBEMEQwIi8+CjxjaXJjbGUgY3g9IjExMCIgY3k9IjcwIiByPSI4IiBmaWxsPSIjQTBBMEEwIi8+CjxwYXRoIGQ9Ik0xMDAgOTBMMTIwIDExMEwxNDAgOTBMMTcwIDEyMEgxMDBWOTBaIiBmaWxsPSIjQTBBMEEwIi8+Cjx0ZXh0IHg9IjE0MCIgeT0iMTcwIiB0ZXh0LWFuY2hvcj0ibWlkZGxlIiBmaWxsPSIjODA4MDgwIiBmb250LWZhbWlseT0iQXJpYWwsIHNhbnMtc2VyaWYiIGZvbnQtc2l6ZT0iMTQiPk9tIEltYWdlPC90ZXh0Pgo8L3N2Zz4K'}
                        alt={property.name}
                        onError={(e) => {
                          const target = e.target as HTMLImageElement;
                          target.src = 'data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iMjgwIiBoZWlnaHQ9IjIwMCIgdmlld0JveD0iMCAwIDI4MCAyMDAiIGZpbGw9Im5vbmUiIHhtbG5zPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2ZyI+CjxyZWN0IHdpZHRoPSIyODAiIGhlaWdodD0iMjAwIiBmaWxsPSIjRjBGMEYwIi8+CjxyZWN0IHg9IjkwIiB5PSI1MCIgd2lkdGg9IjEwMCIgaGVpZ2h0PSIxMDAiIHJ4PSI4IiBmaWxsPSIjRDBEMEQwIi8+CjxjaXJjbGUgY3g9IjExMCIgY3k9IjcwIiByPSI4IiBmaWxsPSIjQTBBMEEwIi8+CjxwYXRoIGQ9Ik0xMDAgOTBMMTIwIDExMEwxNDAgOTBMMTcwIDEyMEgxMDBWOTBaIiBmaWxsPSIjQTBBMEEwIi8+Cjx0ZXh0IHg9IjE0MCIgeT0iMTcwIiB0ZXh0LWFuY2hvcj0ibWlkZGxlIiBmaWxsPSIjODA4MDgwIiBmb250LWZhbWlseT0iQXJpYWwsIHNhbnMtc2VyaWYiIGZvbnQtc2l6ZT0iMTQiPk9tIEltYWdlPC90ZXh0Pgo8L3N2Zz4K';
                        }}
                      />
                      <div className="property-badge">Popüler</div>
                    </div>

                    <div className="property-info">
                      <div className="property-header">
                        <h3 className="property-title">{property.name}</h3>
                        <p className="property-location">
                          📍 {property.location.city}, {property.location.country}
                        </p>
                        <div className="property-rating">
                          <span className="rating-stars">{renderStars(property.rating)}</span>
                          <span className="rating-score">{property.rating}</span>
                          <span className="rating-count">({property.reviewCount} değerlendirme)</span>
                        </div>
                      </div>

                      <div className="property-amenities">
                        <span className="amenity-tag">Ücretsiz WiFi</span>
                        <span className="amenity-tag">Klima</span>
                        <span className="amenity-tag">Otopark</span>
                      </div>

                      <p className="property-description">
                        {property.description || 'Konforlu ve modern konaklama seçeneği. Şehir merkezine yakın konumda, tüm ihtiyaçlarınıza yönelik hizmetler.'}
                      </p>
                    </div>

                    <div className="property-pricing">
                      <div className="availability-status">Müsait</div>
                      <div className="price-main">₺299</div>
                      <div className="price-period">gecelik</div>
                      <button
                        className="view-details-btn"
                        onClick={(e) => {
                          e.stopPropagation();
                          handleViewDetails(property.id);
                        }}
                      >
                        Detayları Gör
                      </button>
                    </div>
                  </div>
                </div>
              ))}
            </div>
          )}
        </main>

        {/* Map Sidebar */}
        <aside className="map-sidebar">
          <div className="map-header">
            <h3 className="map-title">📍 Harita Görünümü</h3>
            <p className="map-subtitle">
              Seçili: {selectedProperty?.name || 'Hiçbiri'} • 
              {properties.filter(p => p.location.geoLocation?.latitude).length} konum
            </p>
          </div>
          <div className="map-container">
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
                        <p>📍 {property.location.city}, {property.location.country}</p>
                        <p>⭐ {property.rating} ({property.reviewCount} değerlendirme)</p>
                        <p><strong>₺299 / gece</strong></p>
                        <button
                          className="btn btn-primary btn-sm"
                          onClick={() => handleViewDetails(property.id)}
                        >
                          Detayları Gör
                        </button>
                      </div>
                    </Popup>
                  </Marker>
                ))}
            </MapContainer>
          </div>
        </aside>
      </div>
    </div>
  );
};

export default BookingHomePage;