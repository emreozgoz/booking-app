import { useState } from 'react';
import type { House, CreateBookingRequest } from '../types';
import { bookingService } from '../services/api';

interface BookingFormProps {
  house: House;
  onClose: () => void;
  onBookingCreated: () => void;
}

const BookingForm = ({ house, onClose, onBookingCreated }: BookingFormProps) => {
  const [formData, setFormData] = useState({
    checkInDate: '',
    checkOutDate: '',
    numberOfGuests: 1,
    specialRequests: ''
  });
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const handleChange = (e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) => {
    const { name, value } = e.target;
    setFormData(prev => ({
      ...prev,
      [name]: name === 'numberOfGuests' ? parseInt(value) : value
    }));
  };

  const calculateTotalAmount = () => {
    if (!formData.checkInDate || !formData.checkOutDate) return 0;
    
    const checkIn = new Date(formData.checkInDate);
    const checkOut = new Date(formData.checkOutDate);
    const nights = Math.ceil((checkOut.getTime() - checkIn.getTime()) / (1000 * 60 * 60 * 24));
    
    return nights > 0 ? nights * house.pricePerNight : 0;
  };

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    setLoading(true);
    setError(null);

    try {
      const bookingRequest: CreateBookingRequest = {
        houseId: house.id,
        userId: 'temp-user-id', // In a real app, this would come from authentication
        checkInDate: formData.checkInDate,
        checkOutDate: formData.checkOutDate,
        numberOfGuests: formData.numberOfGuests,
        specialRequests: formData.specialRequests || undefined
      };

      await bookingService.createBooking(bookingRequest);
      onBookingCreated();
      onClose();
    } catch (error: any) {
      setError(error.response?.data?.message || 'An error occurred while creating the booking');
    } finally {
      setLoading(false);
    }
  };

  const totalAmount = calculateTotalAmount();
  const nights = formData.checkInDate && formData.checkOutDate
    ? Math.ceil((new Date(formData.checkOutDate).getTime() - new Date(formData.checkInDate).getTime()) / (1000 * 60 * 60 * 24))
    : 0;

  return (
    <div className="booking-form-overlay">
      <div className="booking-form">
        <div className="form-header">
          <h2>Book {house.title}</h2>
          <button className="close-btn" onClick={onClose}>×</button>
        </div>
        
        <form onSubmit={handleSubmit}>
          {error && <div className="error">{error}</div>}
          
          <div className="form-group">
            <label htmlFor="checkInDate">Check-in Date</label>
            <input
              type="date"
              id="checkInDate"
              name="checkInDate"
              value={formData.checkInDate}
              onChange={handleChange}
              required
              min={new Date().toISOString().split('T')[0]}
            />
          </div>

          <div className="form-group">
            <label htmlFor="checkOutDate">Check-out Date</label>
            <input
              type="date"
              id="checkOutDate"
              name="checkOutDate"
              value={formData.checkOutDate}
              onChange={handleChange}
              required
              min={formData.checkInDate || new Date().toISOString().split('T')[0]}
            />
          </div>

          <div className="form-group">
            <label htmlFor="numberOfGuests">Number of Guests</label>
            <input
              type="number"
              id="numberOfGuests"
              name="numberOfGuests"
              value={formData.numberOfGuests}
              onChange={handleChange}
              min="1"
              max={house.maxGuests}
              required
            />
          </div>

          <div className="form-group">
            <label htmlFor="specialRequests">Special Requests (Optional)</label>
            <textarea
              id="specialRequests"
              name="specialRequests"
              value={formData.specialRequests}
              onChange={handleChange}
              rows={3}
              placeholder="Any special requests or notes..."
            />
          </div>

          {nights > 0 && (
            <div className="booking-summary">
              <p>${house.pricePerNight} × {nights} nights = ${totalAmount}</p>
            </div>
          )}

          <div className="form-actions">
            <button type="button" onClick={onClose} className="cancel-btn">
              Cancel
            </button>
            <button type="submit" disabled={loading || totalAmount === 0} className="submit-btn">
              {loading ? 'Booking...' : `Book Now - $${totalAmount}`}
            </button>
          </div>
        </form>
      </div>
    </div>
  );
};

export default BookingForm;