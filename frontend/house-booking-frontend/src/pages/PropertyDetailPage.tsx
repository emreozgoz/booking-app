import React, { useState, useEffect } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import { propertyService, reviewService } from '../services/api';

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

interface Review {
  id: string;
  rating: number;
  comment: string;
  createdAt: string;
  userId: string;
}

const PropertyDetailPage: React.FC = () => {
  const { id } = useParams<{ id: string }>();
  const navigate = useNavigate();
  const [property, setProperty] = useState<Property | null>(null);
  const [reviews, setReviews] = useState<Review[]>([]);
  const [loading, setLoading] = useState(true);
  const [checkIn, setCheckIn] = useState('');
  const [checkOut, setCheckOut] = useState('');
  const [guests, setGuests] = useState(1);

  useEffect(() => {
    if (id) {
      fetchProperty();
      fetchReviews();
    }
  }, [id]);

  const fetchProperty = async () => {
    try {
      const response = await propertyService.getPropertyById(id!);
      setProperty(response);
    } catch (error) {
      console.error('Error fetching property:', error);
    }
  };

  const fetchReviews = async () => {
    try {
      const response = await reviewService.getReviews({
        propertyId: id!,
        pageSize: 10,
        isVisible: true
      });
      
      const reviewsData = response.reviews || response.items || response || [];
      setReviews(reviewsData);
    } catch (error) {
      console.error('Error fetching reviews:', error);
    } finally {
      setLoading(false);
    }
  };

  const handleReservation = () => {
    // Navigate to reservation page or show booking modal
    alert('Booking functionality will be implemented soon!');
  };

  const renderStars = (rating: number) => {
    return '★'.repeat(Math.floor(rating)) + '☆'.repeat(5 - Math.floor(rating));
  };

  const formatDate = (dateString: string) => {
    return new Date(dateString).toLocaleDateString('en-US', {
      year: 'numeric',
      month: 'long'
    });
  };

  if (loading) {
    return (
      <div className="loading-container">
        <div className="spinner"></div>
        <p>Loading property details...</p>
      </div>
    );
  }

  if (!property) {
    return (
      <div className="error-container">
        <h2>Property not found</h2>
        <button onClick={() => navigate('/')}>Go back to home</button>
      </div>
    );
  }

  return (
    <div className="property-detail">
      {/* Header */}
      <header className="detail-header">
        <button className="back-btn" onClick={() => navigate('/')}>
          ← Back to search
        </button>
        <div className="header-actions">
          <button className="share-btn">↗ Share</button>
          <button className="save-btn">🤍 Save</button>
        </div>
      </header>

      {/* Property Images */}
      <div className="property-images">
        <div className="main-image">
          <img
            src={property.imageUrl || 'data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iODAwIiBoZWlnaHQ9IjYwMCIgdmlld0JveD0iMCAwIDgwMCA2MDAiIGZpbGw9Im5vbmUiIHhtbG5zPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2ZyI+CjxyZWN0IHdpZHRoPSI4MDAiIGhlaWdodD0iNjAwIiBmaWxsPSIjRjBGMEYwIi8+CjxyZWN0IHg9IjMwMCIgeT0iMjAwIiB3aWR0aD0iMjAwIiBoZWlnaHQ9IjIwMCIgcng9IjE2IiBmaWxsPSIjRDBEMEQwIi8+CjxjaXJjbGUgY3g9IjM0MCIgY3k9IjI0MCIgcj0iMTYiIGZpbGw9IiNBMEEwQTAiLz4KPHBhdGggZD0iTTMyMCAyODBMMzYwIDM0MUw0MDAgMjgwTDQ2MCAzNDBIMzIwVjI4MFoiIGZpbGw9IiNBMEEwQTAiLz4KPHRleHQgeD0iNDAwIiB5PSI0NDAiIHRleHQtYW5jaG9yPSJtaWRkbGUiIGZpbGw9IiM4MDgwODAiIGZvbnQtZmFtaWx5PSJBcmlhbCwgc2Fucy1zZXJpZiIgZm9udC1zaXplPSIyNCI+Tm8gSW1hZ2U8L3RleHQ+Cjwvc3ZnPgo='}
            alt={property.name}
            onError={(e) => {
              const target = e.target as HTMLImageElement;
              target.src = 'data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iODAwIiBoZWlnaHQ9IjYwMCIgdmlld0JveD0iMCAwIDgwMCA2MDAiIGZpbGw9Im5vbmUiIHhtbG5zPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2ZyI+CjxyZWN0IHdpZHRoPSI4MDAiIGhlaWdodD0iNjAwIiBmaWxsPSIjRjBGMEYwIi8+CjxyZWN0IHg9IjMwMCIgeT0iMjAwIiB3aWR0aD0iMjAwIiBoZWlnaHQ9IjIwMCIgcng9IjE2IiBmaWxsPSIjRDBEMEQwIi8+CjxjaXJjbGUgY3g9IjM0MCIgY3k9IjI0MCIgcj0iMTYiIGZpbGw9IiNBMEEwQTAiLz4KPHBhdGggZD0iTTMyMCAyODBMMzYwIDM0MUw0MDAgMjgwTDQ2MCAzNDBIMzIwVjI4MFoiIGZpbGw9IiNBMEEwQTAiLz4KPHRleHQgeD0iNDAwIiB5PSI0NDAiIHRleHQtYW5jaG9yPSJtaWRkbGUiIGZpbGw9IiM4MDgwODAiIGZvbnQtZmFtaWx5PSJBcmlhbCwgc2Fucy1zZXJpZiIgZm9udC1zaXplPSIyNCI+Tm8gSW1hZ2U8L3RleHQ+Cjwvc3ZnPgo=';
            }}
          />
        </div>
        <div className="image-grid">
          {/* Placeholder for additional images */}
          <div className="grid-image">
            <img src="data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iMzAwIiBoZWlnaHQ9IjIwMCIgdmlld0JveD0iMCAwIDMwMCAyMDAiIGZpbGw9Im5vbmUiIHhtbG5zPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2ZyI+CjxyZWN0IHdpZHRoPSIzMDAiIGhlaWdodD0iMjAwIiBmaWxsPSIjRjBGMEYwIi8+CjxyZWN0IHg9IjEwMCIgeT0iNTAiIHdpZHRoPSIxMDAiIGhlaWdodD0iMTAwIiByeD0iOCIgZmlsbD0iI0QwRDBEMCIvPgo8Y2lyY2xlIGN4PSIxMjAiIGN5PSI3MCIgcj0iOCIgZmlsbD0iI0EwQTBBMCIvPgo8cGF0aCBkPSJNMTEwIDkwTDEzMCAxMTBMMTUwIDkwTDE4MCAxMjBIMTEwVjkwWiIgZmlsbD0iI0EwQTBBMCIvPgo8dGV4dCB4PSIxNTAiIHk9IjE3MCIgdGV4dC1hbmNob3I9Im1pZGRsZSIgZmlsbD0iIzgwODA4MCIgZm9udC1mYW1pbHk9IkFyaWFsLCBzYW5zLXNlcmlmIiBmb250LXNpemU9IjE0Ij5JbWFnZSAyPC90ZXh0Pgo8L3N2Zz4K" alt="Property view 2" />
          </div>
          <div className="grid-image">
            <img src="data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iMzAwIiBoZWlnaHQ9IjIwMCIgdmlld0JveD0iMCAwIDMwMCAyMDAiIGZpbGw9Im5vbmUiIHhtbG5zPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2ZyI+CjxyZWN0IHdpZHRoPSIzMDAiIGhlaWdodD0iMjAwIiBmaWxsPSIjRjBGMEYwIi8+CjxyZWN0IHg9IjEwMCIgeT0iNTAiIHdpZHRoPSIxMDAiIGhlaWdodD0iMTAwIiByeD0iOCIgZmlsbD0iI0QwRDBEMCIvPgo8Y2lyY2xlIGN4PSIxMjAiIGN5PSI3MCIgcj0iOCIgZmlsbD0iI0EwQTBBMCIvPgo8cGF0aCBkPSJNMTEwIDkwTDEzMCAxMTBMMTUwIDkwTDE4MCAxMjBIMTEwVjkwWiIgZmlsbD0iI0EwQTBBMCIvPgo8dGV4dCB4PSIxNTAiIHk9IjE3MCIgdGV4dC1hbmNob3I9Im1pZGRsZSIgZmlsbD0iIzgwODA4MCIgZm9udC1mYW1pbHk9IkFyaWFsLCBzYW5zLXNlcmlmIiBmb250LXNpemU9IjE0Ij5JbWFnZSAzPC90ZXh0Pgo8L3N2Zz4K" alt="Property view 3" />
          </div>
          <div className="grid-image">
            <img src="data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iMzAwIiBoZWlnaHQ9IjIwMCIgdmlld0JveD0iMCAwIDMwMCAyMDAiIGZpbGw9Im5vbmUiIHhtbG5zPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2ZyI+CjxyZWN0IHdpZHRoPSIzMDAiIGhlaWdodD0iMjAwIiBmaWxsPSIjRjBGMEYwIi8+CjxyZWN0IHg9IjEwMCIgeT0iNTAiIHdpZHRoPSIxMDAiIGhlaWdodD0iMTAwIiByeD0iOCIgZmlsbD0iI0QwRDBEMCIvPgo8Y2lyY2xlIGN4PSIxMjAiIGN5PSI3MCIgcj0iOCIgZmlsbD0iI0EwQTBBMCIvPgo8cGF0aCBkPSJNMTEwIDkwTDEzMCAxMTBMMTUwIDkwTDE4MCAxMjBIMTEwVjkwWiIgZmlsbD0iI0EwQTBBMCIvPgo8dGV4dCB4PSIxNTAiIHk9IjE3MCIgdGV4dC1hbmNob3I9Im1pZGRsZSIgZmlsbD0iIzgwODA4MCIgZm9udC1mYW1pbHk9IkFyaWFsLCBzYW5zLXNlcmlmIiBmb250LXNpemU9IjE0Ij5JbWFnZSA0PC90ZXh0Pgo8L3N2Zz4K" alt="Property view 4" />
          </div>
          <div className="grid-image">
            <img src="data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iMzAwIiBoZWlnaHQ9IjIwMCIgdmlld0JveD0iMCAwIDMwMCAyMDAiIGZpbGw9Im5vbmUiIHhtbG5zPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2ZyI+CjxyZWN0IHdpZHRoPSIzMDAiIGhlaWdodD0iMjAwIiBmaWxsPSIjRjBGMEYwIi8+CjxyZWN0IHg9IjEwMCIgeT0iNTAiIHdpZHRoPSIxMDAiIGhlaWdodD0iMTAwIiByeD0iOCIgZmlsbD0iI0QwRDBEMCIvPgo8Y2lyY2xlIGN4PSIxMjAiIGN5PSI3MCIgcj0iOCIgZmlsbD0iI0EwQTBBMCIvPgo8cGF0aCBkPSJNMTEwIDkwTDEzMCAxMTBMMTUwIDkwTDE4MCAxMjBIMTEwVjkwWiIgZmlsbD0iI0EwQTBBMCIvPgo8dGV4dCB4PSIxNTAiIHk9IjE3MCIgdGV4dC1hbmNob3I9Im1pZGRsZSIgZmlsbD0iIzgwODA4MCIgZm9udC1mYW1pbHk9IkFyaWFsLCBzYW5zLXNlcmlmIiBmb250LXNpemU9IjE0Ij5JbWFnZSA1PC90ZXh0Pgo8L3N2Zz4K" alt="Property view 5" />
          </div>
        </div>
      </div>

      {/* Property Info */}
      <div className="property-content">
        <div className="property-main">
          <div className="property-header">
            <h1>{property.name}</h1>
            <div className="property-meta">
              <span className="rating">
                ★ {property.rating} · {property.reviewCount} reviews · {property.location.city}, {property.location.country}
              </span>
            </div>
          </div>

          <div className="property-host">
            <div className="host-info">
              <div className="host-avatar">👤</div>
              <div>
                <h4>Hosted by StayBooking</h4>
                <p>Superhost · 2 years hosting</p>
              </div>
            </div>
          </div>

          <div className="property-features">
            <div className="feature">
              <span className="feature-icon">🏠</span>
              <div>
                <h4>Entire home</h4>
                <p>You'll have the property to yourself</p>
              </div>
            </div>
            <div className="feature">
              <span className="feature-icon">✨</span>
              <div>
                <h4>Enhanced Clean</h4>
                <p>This host committed to Airbnb's 5-step enhanced cleaning process</p>
              </div>
            </div>
            <div className="feature">
              <span className="feature-icon">📍</span>
              <div>
                <h4>Great location</h4>
                <p>Recent guests gave the location a 5-star rating</p>
              </div>
            </div>
          </div>

          <div className="property-description">
            <p>{property.description}</p>
          </div>

          <div className="property-amenities">
            <h3>What this place offers</h3>
            <div className="amenities-grid">
              <div className="amenity">🌊 Beach access</div>
              <div className="amenity">🏊 Pool</div>
              <div className="amenity">🅿️ Free parking</div>
              <div className="amenity">📶 Wifi</div>
              <div className="amenity">🍳 Kitchen</div>
              <div className="amenity">❄️ Air conditioning</div>
              <div className="amenity">🔥 Heating</div>
              <div className="amenity">📺 TV</div>
            </div>
          </div>

          {/* Reviews Section */}
          <div className="reviews-section">
            <h3>★ {property.rating} · {property.reviewCount} reviews</h3>
            
            <div className="reviews-grid">
              {reviews.map((review) => (
                <div key={review.id} className="review-card">
                  <div className="review-header">
                    <div className="reviewer-avatar">👤</div>
                    <div className="reviewer-info">
                      <h4>Guest</h4>
                      <p>{formatDate(review.createdAt)}</p>
                    </div>
                  </div>
                  <div className="review-rating">
                    {renderStars(review.rating)}
                  </div>
                  <p className="review-comment">{review.comment}</p>
                </div>
              ))}
            </div>
          </div>
        </div>

        {/* Booking Card */}
        <div className="booking-card">
          <div className="booking-header">
            <div className="price">
              <span className="amount">$99</span>
              <span className="period">night</span>
            </div>
            <div className="booking-rating">
              ★ {property.rating} · {property.reviewCount} reviews
            </div>
          </div>

          <div className="booking-form">
            <div className="date-inputs">
              <div className="date-input">
                <label>CHECK-IN</label>
                <input
                  type="date"
                  value={checkIn}
                  onChange={(e) => setCheckIn(e.target.value)}
                />
              </div>
              <div className="date-input">
                <label>CHECKOUT</label>
                <input
                  type="date"
                  value={checkOut}
                  onChange={(e) => setCheckOut(e.target.value)}
                />
              </div>
            </div>

            <div className="guests-input">
              <label>GUESTS</label>
              <select value={guests} onChange={(e) => setGuests(parseInt(e.target.value))}>
                <option value={1}>1 guest</option>
                <option value={2}>2 guests</option>
                <option value={3}>3 guests</option>
                <option value={4}>4 guests</option>
                <option value={5}>5+ guests</option>
              </select>
            </div>

            <button className="reserve-btn" onClick={handleReservation}>
              Reserve
            </button>

            <p className="booking-note">You won't be charged yet</p>

            <div className="booking-breakdown">
              <div className="breakdown-item">
                <span>$99 x 5 nights</span>
                <span>$495</span>
              </div>
              <div className="breakdown-item">
                <span>Cleaning fee</span>
                <span>$20</span>
              </div>
              <div className="breakdown-item">
                <span>Service fee</span>
                <span>$31</span>
              </div>
              <div className="breakdown-total">
                <span>Total</span>
                <span>$546</span>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default PropertyDetailPage;