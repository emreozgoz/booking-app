import React, { useState, useEffect } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import { propertyService, roomService, reviewService } from '../services/api';
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
  propertyType?: {
    name: string;
    description: string;
    category: string;
  };
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
  ownerId?: string;
  rating: number;
  reviewCount: number;
  isActive: boolean;
  images?: PropertyImage[];
  rooms?: Room[];
  reviews?: Review[];
  createdAt: string;
  updatedAt: string;
}

interface PropertyImage {
  id: string;
  url: string;
  altText?: string;
  isPrimary: boolean;
  order: number;
  isMarkedForDeletion: boolean;
}

interface Room {
  id: string;
  number: string;
  name: string;
  description: string;
  roomType?: {
    name: string;
    description: string;
    capacity: number;
  };
  pricePerNight?: {
    amount: number;
    currency: string;
  };
  maxOccupancy: number;
  size?: number;
  isActive: boolean;
  isRefundable?: boolean;
  images?: RoomImage[];
  amenities?: Amenity[];
  availabilities?: RoomAvailability[];
  priceOverrides?: PriceOverride[];
}

interface RoomImage {
  id: string;
  url: string;
  altText?: string;
  order: number;
}

interface Amenity {
  id: string;
  name: string;
  description: string;
  icon?: string;
}

interface RoomAvailability {
  id: string;
  date: string;
  isAvailable: boolean;
  reason?: string;
}

interface PriceOverride {
  id: string;
  date: string;
  pricePerNight: {
    amount: number;
    currency: string;
  };
  reason?: string;
}

interface Review {
  id: string;
  rating: number;
  title?: string;
  comment: string;
  guestId: string;
  guestName: string;
  isVerified?: boolean;
  verifiedAt?: string;
  verifiedBy?: string;
  isVisible?: boolean;
  isDeleted?: boolean;
  isInappropriate?: boolean;
  createdAt: string;
  updatedAt: string;
}

const BookingPropertyDetailPage: React.FC = () => {
  const { id } = useParams<{ id: string }>();
  const navigate = useNavigate();
  const { user, logout } = useAuth();
  const [property, setProperty] = useState<Property | null>(null);
  const [rooms, setRooms] = useState<Room[]>([]);
  const [reviews, setReviews] = useState<Review[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string>('');
  const [checkIn, setCheckIn] = useState('');
  const [checkOut, setCheckOut] = useState('');
  const [guests, setGuests] = useState(1);
  const [selectedImageIndex, setSelectedImageIndex] = useState(0);
  const [selectedRoom, setSelectedRoom] = useState<Room | null>(null);
  const [isBooking, setIsBooking] = useState(false);

  const handleLogout = () => {
    logout();
  };

  const handleBooking = async () => {
    if (!user) {
      // Redirect to login with current page as return URL
      navigate(`/login?redirect=${encodeURIComponent(window.location.pathname)}`);
      return;
    }

    if (!checkIn || !checkOut) {
      alert('Lütfen giriş ve çıkış tarihlerini seçin.');
      return;
    }

    if (!selectedRoom) {
      alert('Lütfen bir oda seçin.');
      return;
    }

    try {
      setIsBooking(true);
      
      // Here you would make the booking API call
      // const bookingData = {
      //   propertyId: property.id,
      //   roomId: selectedRoom.id,
      //   checkIn,
      //   checkOut,
      //   guests,
      //   userId: user.id
      // };
      // await bookingService.createBooking(bookingData);
      
      // For now, show success message
      alert('🎉 Rezervasyon başarılı! Rezervasyon detaylarınız e-posta adresinize gönderildi.');
      
    } catch (error) {
      console.error('Booking error:', error);
      alert('Rezervasyon yapılırken bir hata oluştu. Lütfen tekrar deneyin.');
    } finally {
      setIsBooking(false);
    }
  };

  useEffect(() => {
    if (id) {
      fetchAllData(id);
    }
  }, [id]);

  const fetchAllData = async (propertyId: string) => {
    try {
      setLoading(true);
      setError('');

      // Fetch property details first
      const propertyResponse = await propertyService.getProperty(propertyId);
      setProperty(propertyResponse);

      // Fetch rooms for this property
      try {
        const roomsResponse = await roomService.getRooms({
          propertyId,
          pageSize: 50,
          isActive: true
        });
        const roomsData = roomsResponse.rooms || roomsResponse.items || roomsResponse || [];
        setRooms(Array.isArray(roomsData) ? roomsData : []);
        if (roomsData.length > 0) {
          setSelectedRoom(roomsData[0]);
        }
      } catch (roomError) {
        console.warn('Could not fetch rooms:', roomError);
        // Use rooms from property if available
        if (propertyResponse.rooms) {
          setRooms(propertyResponse.rooms);
          if (propertyResponse.rooms.length > 0) {
            setSelectedRoom(propertyResponse.rooms[0]);
          }
        }
      }

      // Fetch reviews for this property
      try {
        const reviewsResponse = await reviewService.getReviews({
          propertyId,
          pageSize: 20,
          isVisible: true
        });
        const reviewsData = reviewsResponse.reviews || reviewsResponse.items || reviewsResponse || [];
        setReviews(Array.isArray(reviewsData) ? reviewsData : []);
      } catch (reviewError) {
        console.warn('Could not fetch reviews:', reviewError);
        // Use reviews from property if available
        if (propertyResponse.reviews) {
          setReviews(propertyResponse.reviews);
        }
      }

    } catch (error) {
      console.error('Error fetching property data:', error);
      setError('Konaklama bilgileri yüklenemedi. Lütfen daha sonra tekrar deneyin.');
    } finally {
      setLoading(false);
    }
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

  const calculateNights = () => {
    if (checkIn && checkOut) {
      const start = new Date(checkIn);
      const end = new Date(checkOut);
      const diffTime = Math.abs(end.getTime() - start.getTime());
      const diffDays = Math.ceil(diffTime / (1000 * 60 * 60 * 24));
      return diffDays;
    }
    return 0;
  };

  const getBasePrice = () => {
    if (selectedRoom && selectedRoom.pricePerNight) {
      return selectedRoom.pricePerNight.amount;
    }
    return 299; // Default price
  };

  const calculateTotalPrice = () => {
    const nights = calculateNights();
    const basePrice = getBasePrice();
    const subtotal = nights * basePrice;
    const taxes = Math.round(subtotal * 0.18);
    const serviceFee = Math.round(subtotal * 0.05);
    return {
      nights,
      basePrice,
      subtotal,
      taxes,
      serviceFee,
      total: subtotal + taxes + serviceFee
    };
  };

  // Get images from property data or use defaults
  const getPropertyImages = () => {
    if (property?.images && property.images.length > 0) {
      return property.images
        .filter(img => !img.isMarkedForDeletion)
        .sort((a, b) => {
          if (a.isPrimary && !b.isPrimary) return -1;
          if (!a.isPrimary && b.isPrimary) return 1;
          return a.order - b.order;
        })
        .map(img => img.url);
    }

    // Fallback to property imageUrl or default
    return [
      property?.imageUrl || 'data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iODAwIiBoZWlnaHQ9IjQwMCIgdmlld0JveD0iMCAwIDgwMCA0MDAiIGZpbGw9Im5vbmUiIHhtbG5zPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2ZyI+CjxyZWN0IHdpZHRoPSI4MDAiIGhlaWdodD0iNDAwIiBmaWxsPSIjRjBGMEYwIi8+CjxyZWN0IHg9IjMwMCIgeT0iMTUwIiB3aWR0aD0iMjAwIiBoZWlnaHQ9IjEwMCIgcng9IjgiIGZpbGw9IiNEMEQwRDAiLz4KPGNpcmNsZSBjeD0iMzUwIiBjeT0iMTgwIiByPSIxNSIgZmlsbD0iI0EwQTBBMCIvPgo8cGF0aCBkPSJNMzIwIDIyMEwzNjAgMjYwTDQwMCAyMjBMNDgwIDMwMEgzMjBWMjIwWiIgZmlsbD0iI0EwQTBBMCIvPgo8dGV4dCB4PSI0MDAiIHk9IjM1MCIgdGV4dC1hbmNob3I9Im1pZGRsZSIgZmlsbD0iIzgwODA4MCIgZm9udC1mYW1pbHk9IkFyaWFsLCBzYW5zLXNlcmlmIiBmb250LXNpemU9IjI0Ij5Qcm9wZXJ0eSBJbWFnZTwvdGV4dD4KPC9zdmc+Cg=='
    ];
  };

  const displayImages = getPropertyImages();
  while (displayImages.length < 5) {
    displayImages.push('data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iODAwIiBoZWlnaHQ9IjQwMCIgdmlld0JveD0iMCAwIDgwMCA0MDAiIGZpbGw9Im5vbmUiIHhtbG5zPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2ZyI+CjxyZWN0IHdpZHRoPSI4MDAiIGhlaWdodD0iNDAwIiBmaWxsPSIjRjBGMEYwIi8+CjxyZWN0IHg9IjMwMCIgeT0iMTUwIiB3aWR0aD0iMjAwIiBoZWlnaHQ9IjEwMCIgcng9IjgiIGZpbGw9IiNEMEQwRDAiLz4KPGNpcmNsZSBjeD0iMzUwIiBjeT0iMTgwIiByPSIxNSIgZmlsbD0iI0EwQTBBMCIvPgo8cGF0aCBkPSJNMzIwIDIyMEwzNjAgMjYwTDQwMCAyMjBMNDgwIDMwMEgzMjBWMjIwWiIgZmlsbD0iI0EwQTBBMCIvPgo8dGV4dCB4PSI0MDAiIHk9IjM1MCIgdGV4dC1hbmNob3I9Im1pZGRsZSIgZmlsbD0iIzgwODA4MCIgZm9udC1mYW1pbHk9IkFyaWFsLCBzYW5zLXNlcmlmIiBmb250LXNpemU9IjI0Ij5Qcm9wZXJ0eSBJbWFnZTwvdGV4dD4KPC9zdmc+Cg==');
  }

  // Get amenities from rooms or use defaults
  const getAmenities = () => {
    if (rooms.length > 0) {
      const allAmenities = rooms.flatMap(room => room.amenities || []);
      const uniqueAmenities = allAmenities.reduce((unique, amenity) => {
        if (!unique.find(a => a.id === amenity.id)) {
          unique.push(amenity);
        }
        return unique;
      }, [] as Amenity[]);

      if (uniqueAmenities.length > 0) {
        return uniqueAmenities;
      }
    }

    // Default amenities
    return [
      { id: '1', icon: '📶', name: 'Ücretsiz WiFi', description: 'Tüm alanlarda ücretsiz internet' },
      { id: '2', icon: '❄️', name: 'Klima', description: 'Merkezi havalandırma sistemi' },
      { id: '3', icon: '🅿️', name: 'Ücretsiz Otopark', description: 'Kendi otoparkımızda güvenli park' },
      { id: '4', icon: '🏊‍♀️', name: 'Yüzme Havuzu', description: 'Açık havuz ve çocuk havuzu' },
      { id: '5', icon: '🏋️‍♂️', name: 'Fitness Center', description: '7/24 açık modern spor salonu' },
      { id: '6', icon: '🛎️', name: '24/7 Resepsiyon', description: 'Sürekli müşteri hizmetleri' },
      { id: '7', icon: '🧹', name: 'Günlük Temizlik', description: 'Profesyonel temizlik hizmeti' },
      { id: '8', icon: '🍳', name: 'Kahvaltı', description: 'Zengin açık büfe kahvaltı' },
    ];
  };

  const displayAmenities = getAmenities();

  if (loading) {
    return (
      <div className="booking-app">
        <div className="loading-spinner" style={{ minHeight: '100vh' }}>
          <div className="spinner"></div>
          <p className="loading-text">Konaklama detayları yükleniyor...</p>
        </div>
      </div>
    );
  }

  if (error || !property) {
    return (
      <div className="booking-app">
        <div className="empty-state" style={{ minHeight: '100vh' }}>
          <div className="empty-icon">❌</div>
          <h3 className="empty-title">Konaklama bulunamadı</h3>
          <p className="empty-subtitle">{error || 'Aradığınız konaklama mevcut değil'}</p>
          <button className="btn btn-primary" onClick={() => navigate('/')}>
            Ana Sayfaya Dön
          </button>
        </div>
      </div>
    );
  }

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
            <button className="nav-link" onClick={() => navigate('/')}>
              ← Geri Dön
            </button>
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

      <div style={{ padding: '40px 0' }}>
        <div className="header-container">
          {/* Property Header */}
          <div style={{ marginBottom: '32px' }}>
            <h1 style={{ fontSize: '32px', fontWeight: '700', marginBottom: '8px', color: 'var(--text-dark)' }}>
              {property.name}
            </h1>
            <div style={{ display: 'flex', alignItems: 'center', gap: '16px', marginBottom: '8px' }}>
              <div style={{ display: 'flex', alignItems: 'center', gap: '8px' }}>
                <span style={{ color: 'var(--secondary-orange)' }}>{renderStars(property.rating)}</span>
                <span style={{ fontWeight: '600' }}>{property.rating}</span>
                <span style={{ color: 'var(--text-medium)' }}>({property.reviewCount} değerlendirme)</span>
              </div>
              <span style={{ color: 'var(--text-medium)' }}>•</span>
              <span style={{ color: 'var(--text-medium)' }}>
                📍 {property.location.city}, {property.location.country}
              </span>
            </div>
            {property.location.address && (
              <p style={{ color: 'var(--text-medium)', fontSize: '14px' }}>
                {property.location.address}
              </p>
            )}
          </div>

          {/* Property Images */}
          <div style={{ marginBottom: '40px' }}>
            <div style={{ 
              display: 'grid', 
              gridTemplateColumns: '2fr 1fr 1fr', 
              gap: '8px', 
              height: '400px',
              borderRadius: '12px',
              overflow: 'hidden'
            }}>
              <div style={{ position: 'relative' }}>
                <img
                  src={displayImages[0]}
                  alt={property.name}
                  style={{ 
                    width: '100%', 
                    height: '100%', 
                    objectFit: 'cover',
                    cursor: 'pointer'
                  }}
                  onClick={() => setSelectedImageIndex(0)}
                />
              </div>
              <div style={{ display: 'grid', gridTemplateRows: '1fr 1fr', gap: '8px' }}>
                <img
                  src={displayImages[1]}
                  alt={property.name}
                  style={{ 
                    width: '100%', 
                    height: '100%', 
                    objectFit: 'cover',
                    cursor: 'pointer'
                  }}
                  onClick={() => setSelectedImageIndex(1)}
                />
                <img
                  src={displayImages[2]}
                  alt={property.name}
                  style={{ 
                    width: '100%', 
                    height: '100%', 
                    objectFit: 'cover',
                    cursor: 'pointer'
                  }}
                  onClick={() => setSelectedImageIndex(2)}
                />
              </div>
              <div style={{ display: 'grid', gridTemplateRows: '1fr 1fr', gap: '8px' }}>
                <img
                  src={displayImages[3]}
                  alt={property.name}
                  style={{ 
                    width: '100%', 
                    height: '100%', 
                    objectFit: 'cover',
                    cursor: 'pointer'
                  }}
                  onClick={() => setSelectedImageIndex(3)}
                />
                <div style={{ position: 'relative' }}>
                  <img
                    src={displayImages[4]}
                    alt={property.name}
                    style={{ 
                      width: '100%', 
                      height: '100%', 
                      objectFit: 'cover',
                      cursor: 'pointer'
                    }}
                    onClick={() => setSelectedImageIndex(4)}
                  />
                  {displayImages.length > 5 && (
                    <div style={{
                      position: 'absolute',
                      bottom: '12px',
                      right: '12px',
                      background: 'rgba(0,0,0,0.7)',
                      color: 'white',
                      padding: '8px 12px',
                      borderRadius: '6px',
                      fontSize: '14px',
                      fontWeight: '500'
                    }}>
                      +{displayImages.length - 5} fotoğraf
                    </div>
                  )}
                </div>
              </div>
            </div>
          </div>

          {/* Main Content */}
          <div style={{ 
            display: 'grid', 
            gridTemplateColumns: '2fr 1fr', 
            gap: '60px'
          }}>
            {/* Left Column */}
            <div>
              {/* Property Info */}
              <div style={{ marginBottom: '40px' }}>
                <h2 style={{ fontSize: '24px', fontWeight: '600', marginBottom: '16px' }}>
                  Konaklama Hakkında
                </h2>
                <p style={{ 
                  color: 'var(--text-medium)', 
                  lineHeight: '1.6',
                  fontSize: '16px'
                }}>
                  {property.description || 'Bu muhteşem konaklama, modern konfor ve geleneksel misafirperverliği bir araya getiriyor. Şehrin kalbinde yer alan bu özel mekân, hem iş hem de tatil amaçlı konaklamalar için mükemmel. Deneyimli personelimiz ve kaliteli hizmetimizle unutulmaz bir konaklama deneyimi sunuyoruz.'}
                </p>
              </div>

              {/* Rooms Section */}
              {rooms.length > 0 && (
                <div style={{ marginBottom: '40px' }}>
                  <h2 style={{ fontSize: '24px', fontWeight: '600', marginBottom: '24px' }}>
                    Odalar ({rooms.length})
                  </h2>
                  <div style={{ display: 'grid', gap: '16px' }}>
                    {rooms.slice(0, 3).map((room, index) => (
                      <div key={room.id} style={{
                        border: '1px solid var(--border-light)',
                        borderRadius: '12px',
                        padding: '20px',
                        background: selectedRoom?.id === room.id ? 'var(--primary-blue-light)' : 'white',
                        cursor: 'pointer',
                        transition: 'all 0.2s ease'
                      }}
                      onClick={() => setSelectedRoom(room)}
                      >
                        <div style={{ display: 'grid', gridTemplateColumns: 'auto 1fr auto', gap: '16px', alignItems: 'center' }}>
                          <div style={{
                            width: '60px',
                            height: '60px',
                            borderRadius: '8px',
                            background: 'var(--background-light)',
                            display: 'flex',
                            alignItems: 'center',
                            justifyContent: 'center',
                            fontSize: '24px'
                          }}>
                            🏨
                          </div>
                          <div>
                            <h4 style={{ fontWeight: '600', marginBottom: '4px' }}>
                              {room.name || `Oda ${room.number}`}
                            </h4>
                            <p style={{ color: 'var(--text-medium)', fontSize: '14px', marginBottom: '4px' }}>
                              {room.roomType?.name || 'Standart Oda'} • {room.maxOccupancy} kişi
                            </p>
                            <p style={{ color: 'var(--text-medium)', fontSize: '12px' }}>
                              {room.description || 'Konforlu ve modern oda'}
                            </p>
                          </div>
                          <div style={{ textAlign: 'right' }}>
                            <div style={{ fontSize: '18px', fontWeight: '600', color: 'var(--primary-blue)' }}>
                              ₺{room.pricePerNight?.amount || 299}
                            </div>
                            <div style={{ fontSize: '12px', color: 'var(--text-medium)' }}>
                              gecelik
                            </div>
                          </div>
                        </div>
                      </div>
                    ))}
                  </div>
                </div>
              )}

              {/* Amenities */}
              <div style={{ marginBottom: '40px' }}>
                <h2 style={{ fontSize: '24px', fontWeight: '600', marginBottom: '24px' }}>
                  Olanaklar
                </h2>
                <div style={{ 
                  display: 'grid', 
                  gridTemplateColumns: 'repeat(auto-fit, minmax(300px, 1fr))', 
                  gap: '24px'
                }}>
                  {displayAmenities.slice(0, 8).map((amenity, index) => (
                    <div key={amenity.id || index} style={{ 
                      display: 'flex', 
                      alignItems: 'flex-start', 
                      gap: '16px',
                      padding: '16px',
                      border: '1px solid var(--border-light)',
                      borderRadius: 'var(--border-radius)',
                      background: 'var(--background-white)'
                    }}>
                      <span style={{ fontSize: '24px' }}>{amenity.icon}</span>
                      <div>
                        <h4 style={{ fontWeight: '600', marginBottom: '4px' }}>
                          {amenity.name}
                        </h4>
                        <p style={{ color: 'var(--text-medium)', fontSize: '14px' }}>
                          {amenity.description}
                        </p>
                      </div>
                    </div>
                  ))}
                </div>
              </div>

              {/* Map */}
              {property.location.geoLocation && (
                <div style={{ marginBottom: '40px' }}>
                  <h2 style={{ fontSize: '24px', fontWeight: '600', marginBottom: '16px' }}>
                    Konum
                  </h2>
                  <div style={{ 
                    height: '300px', 
                    borderRadius: '12px', 
                    overflow: 'hidden',
                    border: '1px solid var(--border-light)'
                  }}>
                    <MapContainer
                      center={[property.location.geoLocation.latitude, property.location.geoLocation.longitude]}
                      zoom={15}
                      scrollWheelZoom={true}
                      style={{ height: '100%', width: '100%' }}
                    >
                      <TileLayer
                        attribution='&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
                        url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"
                      />
                      <Marker
                        position={[property.location.geoLocation.latitude, property.location.geoLocation.longitude]}
                        icon={customIcon}
                      >
                        <Popup>
                          <div>
                            <h4>{property.name}</h4>
                            <p>📍 {property.location.city}, {property.location.country}</p>
                          </div>
                        </Popup>
                      </Marker>
                    </MapContainer>
                  </div>
                </div>
              )}

              {/* Reviews */}
              <div style={{ marginBottom: '40px' }}>
                <div style={{ 
                  display: 'flex', 
                  alignItems: 'center', 
                  gap: '16px',
                  marginBottom: '24px' 
                }}>
                  <h2 style={{ fontSize: '24px', fontWeight: '600' }}>
                    Değerlendirmeler
                  </h2>
                  <div style={{ display: 'flex', alignItems: 'center', gap: '8px' }}>
                    <span style={{ color: 'var(--secondary-orange)' }}>{renderStars(property.rating)}</span>
                    <span style={{ fontWeight: '600' }}>{property.rating}</span>
                    <span style={{ color: 'var(--text-medium)' }}>({property.reviewCount} değerlendirme)</span>
                  </div>
                </div>
                
                {reviews.length > 0 ? (
                  <div style={{ 
                    display: 'grid', 
                    gridTemplateColumns: 'repeat(auto-fit, minmax(300px, 1fr))', 
                    gap: '24px'
                  }}>
                    {reviews.slice(0, 4).map((review) => (
                      <div key={review.id} style={{
                        padding: '20px',
                        border: '1px solid var(--border-light)',
                        borderRadius: '12px',
                        background: 'var(--background-white)'
                      }}>
                        <div style={{ 
                          display: 'flex', 
                          alignItems: 'center', 
                          gap: '12px',
                          marginBottom: '12px' 
                        }}>
                          <div style={{
                            width: '40px',
                            height: '40px',
                            borderRadius: '50%',
                            background: 'var(--primary-blue)',
                            color: 'white',
                            display: 'flex',
                            alignItems: 'center',
                            justifyContent: 'center',
                            fontWeight: '600'
                          }}>
                            {review.guestName ? review.guestName.charAt(0).toUpperCase() : 'M'}
                          </div>
                          <div>
                            <h4 style={{ fontWeight: '600', marginBottom: '2px' }}>
                              {review.guestName || 'Misafir'}
                            </h4>
                            <div style={{ display: 'flex', alignItems: 'center', gap: '8px' }}>
                              <span style={{ color: 'var(--secondary-orange)' }}>
                                {renderStars(review.rating)}
                              </span>
                              <span style={{ color: 'var(--text-medium)', fontSize: '12px' }}>
                                {new Date(review.createdAt).toLocaleDateString('tr-TR')}
                              </span>
                            </div>
                          </div>
                        </div>
                        <p style={{ 
                          color: 'var(--text-medium)', 
                          lineHeight: '1.5',
                          fontSize: '14px'
                        }}>
                          {review.comment}
                        </p>
                      </div>
                    ))}
                  </div>
                ) : (
                  <div style={{ 
                    textAlign: 'center', 
                    padding: '40px',
                    color: 'var(--text-medium)' 
                  }}>
                    <p>Henüz değerlendirme bulunmuyor.</p>
                  </div>
                )}
              </div>
            </div>

            {/* Right Column - Booking Card */}
            <div style={{ position: 'sticky', top: '100px', height: 'fit-content' }}>
              <div style={{
                background: 'white',
                border: '1px solid var(--border-light)',
                borderRadius: '12px',
                padding: '24px',
                boxShadow: 'var(--shadow-medium)'
              }}>
                <div style={{ 
                  display: 'flex', 
                  alignItems: 'center', 
                  justifyContent: 'space-between',
                  marginBottom: '24px',
                  paddingBottom: '16px',
                  borderBottom: '1px solid var(--border-light)'
                }}>
                  <div>
                    <span style={{ fontSize: '24px', fontWeight: '700' }}>₺{getBasePrice()}</span>
                    <span style={{ color: 'var(--text-medium)', marginLeft: '4px' }}>/gece</span>
                  </div>
                  <div style={{ display: 'flex', alignItems: 'center', gap: '8px' }}>
                    <span style={{ color: 'var(--secondary-orange)' }}>{renderStars(property.rating)}</span>
                    <span style={{ fontWeight: '600' }}>{property.rating}</span>
                    <span style={{ color: 'var(--text-medium)', fontSize: '14px' }}>
                      ({property.reviewCount})
                    </span>
                  </div>
                </div>

                {/* Room Selection */}
                {rooms.length > 1 && (
                  <div style={{ marginBottom: '16px' }}>
                    <label style={{ 
                      display: 'block',
                      fontSize: '12px',
                      fontWeight: '600',
                      color: 'var(--text-medium)',
                      marginBottom: '8px',
                      textTransform: 'uppercase'
                    }}>
                      Oda Seçin
                    </label>
                    <select
                      value={selectedRoom?.id || ''}
                      onChange={(e) => {
                        const room = rooms.find(r => r.id === e.target.value);
                        setSelectedRoom(room || null);
                      }}
                      style={{
                        width: '100%',
                        padding: '12px',
                        border: '1px solid var(--border-light)',
                        borderRadius: 'var(--border-radius)',
                        fontSize: '14px',
                        background: 'white'
                      }}
                    >
                      {rooms.map(room => (
                        <option key={room.id} value={room.id}>
                          {room.name || `Oda ${room.number}`} - ₺{room.pricePerNight?.amount || 299}
                        </option>
                      ))}
                    </select>
                  </div>
                )}

                {/* Booking Form */}
                <div style={{ marginBottom: '24px' }}>
                  <div style={{
                    display: 'grid',
                    gridTemplateColumns: '1fr 1fr',
                    border: '1px solid var(--border-light)',
                    borderRadius: 'var(--border-radius)',
                    overflow: 'hidden',
                    marginBottom: '16px'
                  }}>
                    <div style={{ padding: '12px', borderRight: '1px solid var(--border-light)' }}>
                      <label style={{ 
                        display: 'block',
                        fontSize: '12px',
                        fontWeight: '600',
                        color: 'var(--text-medium)',
                        marginBottom: '4px',
                        textTransform: 'uppercase'
                      }}>
                        Giriş
                      </label>
                      <input
                        type="date"
                        value={checkIn}
                        onChange={(e) => setCheckIn(e.target.value)}
                        style={{
                          width: '100%',
                          border: 'none',
                          outline: 'none',
                          fontSize: '14px',
                          background: 'transparent'
                        }}
                      />
                    </div>
                    <div style={{ padding: '12px' }}>
                      <label style={{ 
                        display: 'block',
                        fontSize: '12px',
                        fontWeight: '600',
                        color: 'var(--text-medium)',
                        marginBottom: '4px',
                        textTransform: 'uppercase'
                      }}>
                        Çıkış
                      </label>
                      <input
                        type="date"
                        value={checkOut}
                        onChange={(e) => setCheckOut(e.target.value)}
                        style={{
                          width: '100%',
                          border: 'none',
                          outline: 'none',
                          fontSize: '14px',
                          background: 'transparent'
                        }}
                      />
                    </div>
                  </div>

                  <div style={{
                    border: '1px solid var(--border-light)',
                    borderRadius: 'var(--border-radius)',
                    padding: '12px',
                    marginBottom: '20px'
                  }}>
                    <label style={{ 
                      display: 'block',
                      fontSize: '12px',
                      fontWeight: '600',
                      color: 'var(--text-medium)',
                      marginBottom: '4px',
                      textTransform: 'uppercase'
                    }}>
                      Misafir
                    </label>
                    <select
                      value={guests}
                      onChange={(e) => setGuests(parseInt(e.target.value))}
                      style={{
                        width: '100%',
                        border: 'none',
                        outline: 'none',
                        fontSize: '14px',
                        background: 'transparent'
                      }}
                    >
                      <option value={1}>1 Misafir</option>
                      <option value={2}>2 Misafir</option>
                      <option value={3}>3 Misafir</option>
                      <option value={4}>4 Misafir</option>
                      <option value={5}>5+ Misafir</option>
                    </select>
                  </div>

                  <button 
                    className="btn btn-primary" 
                    style={{ 
                      width: '100%', 
                      padding: '16px',
                      opacity: isBooking ? '0.7' : '1',
                      cursor: isBooking ? 'not-allowed' : 'pointer'
                    }}
                    onClick={handleBooking}
                    disabled={isBooking}
                  >
                    {isBooking ? (
                      <div style={{ display: 'flex', alignItems: 'center', justifyContent: 'center', gap: '8px' }}>
                        <div style={{
                          width: '16px',
                          height: '16px',
                          border: '2px solid rgba(255,255,255,0.3)',
                          borderTop: '2px solid white',
                          borderRadius: '50%',
                          animation: 'spin 1s linear infinite'
                        }}></div>
                        Rezervasyon Yapılıyor...
                      </div>
                    ) : user ? (
                      'Rezervasyon Yap'
                    ) : (
                      'Giriş Yapıp Rezervasyon Yap'
                    )}
                  </button>
                </div>

                <p style={{ 
                  textAlign: 'center', 
                  color: 'var(--text-medium)', 
                  fontSize: '14px',
                  marginBottom: '16px' 
                }}>
                  {user ? 'Henüz ödeme yapılmayacak' : 'Rezervasyon yapmak için giriş yapmanız gerekir'}
                </p>

                {/* Price Breakdown */}
                {checkIn && checkOut && (
                  <div style={{
                    borderTop: '1px solid var(--border-light)',
                    paddingTop: '16px'
                  }}>
                    {(() => {
                      const pricing = calculateTotalPrice();
                      return (
                        <div>
                          <div style={{ 
                            display: 'flex', 
                            justifyContent: 'space-between',
                            marginBottom: '8px'
                          }}>
                            <span>₺{pricing.basePrice} x {pricing.nights} gece</span>
                            <span>₺{pricing.subtotal}</span>
                          </div>
                          <div style={{ 
                            display: 'flex', 
                            justifyContent: 'space-between',
                            marginBottom: '8px'
                          }}>
                            <span>Hizmet bedeli</span>
                            <span>₺{pricing.serviceFee}</span>
                          </div>
                          <div style={{ 
                            display: 'flex', 
                            justifyContent: 'space-between',
                            marginBottom: '16px'
                          }}>
                            <span>Vergiler</span>
                            <span>₺{pricing.taxes}</span>
                          </div>
                          <div style={{
                            display: 'flex',
                            justifyContent: 'space-between',
                            paddingTop: '16px',
                            borderTop: '1px solid var(--border-light)',
                            fontWeight: '600',
                            fontSize: '16px'
                          }}>
                            <span>Toplam</span>
                            <span>₺{pricing.total}</span>
                          </div>
                        </div>
                      );
                    })()}
                  </div>
                )}
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default BookingPropertyDetailPage;