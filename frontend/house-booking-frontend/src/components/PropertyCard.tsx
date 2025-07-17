import type { Property } from '../types';

interface PropertyCardProps {
  property: Property;
  onBookNow: (property: Property) => void;
}

const PropertyCard = ({ property, onBookNow }: PropertyCardProps) => {
  return (
    <div className="property-card">
      <div className="property-image">
        <img src={property.imageUrl || '/placeholder-property.jpg'} alt={property.name} />
        <div className="property-rating">
          <span className="rating-star">★</span>
          <span className="rating-value">{property.rating}</span>
          <span className="rating-count">({property.reviewCount} reviews)</span>
        </div>
      </div>
      <div className="property-info">
        <h3>{property.name}</h3>
        <p className="property-type">{property.propertyType}</p>
        <p className="property-location">
          <span className="location-icon">📍</span>
          {property.location}
        </p>
        <p className="property-description">{property.description}</p>
        <div className="property-details">
          <span className="detail-item">
            <span className="detail-icon">🏠</span>
            {property.availableRooms} rooms available
          </span>
        </div>
        <div className="property-price">
          <span className="price-from">Starting from</span>
          <span className="price">{property.pricePerNight}/night</span>
        </div>
        <button 
          className="book-now-btn"
          onClick={() => onBookNow(property)}
          disabled={!property.isActive || property.availableRooms === 0}
        >
          {property.isActive && property.availableRooms > 0 ? 'Book Now' : 'Not Available'}
        </button>
      </div>
    </div>
  );
};

export default PropertyCard;