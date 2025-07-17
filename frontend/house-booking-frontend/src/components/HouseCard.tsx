import type { House } from '../types';

interface HouseCardProps {
  house: House;
  onBookNow: (house: House) => void;
}

const HouseCard = ({ house, onBookNow }: HouseCardProps) => {
  return (
    <div className="house-card">
      <div className="house-image">
        <img src={house.imageUrl || '/placeholder-house.jpg'} alt={house.title} />
      </div>
      <div className="house-info">
        <h3>{house.title}</h3>
        <p className="address">{house.address}</p>
        <p className="description">{house.description}</p>
        <div className="house-details">
          <span>{house.maxGuests} guests</span>
          <span>{house.bedrooms} bedrooms</span>
          <span>{house.bathrooms} bathrooms</span>
        </div>
        <div className="house-price">
          <span className="price">${house.pricePerNight}/night</span>
        </div>
        <button 
          className="book-now-btn"
          onClick={() => onBookNow(house)}
          disabled={!house.isAvailable}
        >
          {house.isAvailable ? 'Book Now' : 'Not Available'}
        </button>
      </div>
    </div>
  );
};

export default HouseCard;