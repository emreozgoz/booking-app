import { useState, useEffect } from 'react';
import type { House } from '../types';
import { houseService } from '../services/api';
import HouseCard from './HouseCard';

interface HouseListProps {
  onBookNow: (house: House) => void;
}

const HouseList = ({ onBookNow }: HouseListProps) => {
  const [houses, setHouses] = useState<House[]>([]);
  const [loading, setLoading] = useState(true);
  const [searchTerm, setSearchTerm] = useState('');
  const [minPrice, setMinPrice] = useState<number | undefined>();
  const [maxPrice, setMaxPrice] = useState<number | undefined>();

  useEffect(() => {
    fetchHouses();
  }, [searchTerm, minPrice, maxPrice]);

  const fetchHouses = async () => {
    try {
      setLoading(true);
      const data = await houseService.getHouses({
        searchTerm,
        minPrice,
        maxPrice,
        pageNumber: 1,
        pageSize: 20
      });
      setHouses(data);
    } catch (error) {
      console.error('Error fetching houses:', error);
    } finally {
      setLoading(false);
    }
  };

  const handleSearch = (e: React.FormEvent) => {
    e.preventDefault();
    fetchHouses();
  };

  if (loading) {
    return <div className="loading">Loading houses...</div>;
  }

  return (
    <div className="house-list">
      <div className="search-filters">
        <form onSubmit={handleSearch} className="search-form">
          <input
            type="text"
            placeholder="Search houses..."
            value={searchTerm}
            onChange={(e) => setSearchTerm(e.target.value)}
            className="search-input"
          />
          <input
            type="number"
            placeholder="Min price"
            value={minPrice || ''}
            onChange={(e) => setMinPrice(e.target.value ? Number(e.target.value) : undefined)}
            className="price-input"
          />
          <input
            type="number"
            placeholder="Max price"
            value={maxPrice || ''}
            onChange={(e) => setMaxPrice(e.target.value ? Number(e.target.value) : undefined)}
            className="price-input"
          />
          <button type="submit" className="search-btn">Search</button>
        </form>
      </div>
      
      <div className="houses-grid">
        {houses.length === 0 ? (
          <div className="no-houses">No houses found</div>
        ) : (
          houses.map((house) => (
            <HouseCard key={house.id} house={house} onBookNow={onBookNow} />
          ))
        )}
      </div>
    </div>
  );
};

export default HouseList;