import { useState, useEffect } from 'react';
import type { Booking } from '../types';
import { BookingStatus } from '../types';
import { bookingService } from '../services/api';

const BookingList = () => {
  const [bookings, setBookings] = useState<Booking[]>([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    fetchBookings();
  }, []);

  const fetchBookings = async () => {
    try {
      setLoading(true);
      // In a real app, this would come from authentication
      const data = await bookingService.getBookingsByUser('temp-user-id');
      setBookings(data);
    } catch (error) {
      console.error('Error fetching bookings:', error);
    } finally {
      setLoading(false);
    }
  };

  const formatDate = (dateString: string) => {
    return new Date(dateString).toLocaleDateString();
  };

  const getStatusText = (status: BookingStatus) => {
    switch (status) {
      case BookingStatus.Pending:
        return 'Pending';
      case BookingStatus.Confirmed:
        return 'Confirmed';
      case BookingStatus.Cancelled:
        return 'Cancelled';
      case BookingStatus.Completed:
        return 'Completed';
      default:
        return 'Unknown';
    }
  };

  const getStatusClass = (status: BookingStatus) => {
    switch (status) {
      case BookingStatus.Pending:
        return 'status-pending';
      case BookingStatus.Confirmed:
        return 'status-confirmed';
      case BookingStatus.Cancelled:
        return 'status-cancelled';
      case BookingStatus.Completed:
        return 'status-completed';
      default:
        return '';
    }
  };

  if (loading) {
    return <div className="loading">Loading bookings...</div>;
  }

  return (
    <div className="booking-list">
      <h2>My Bookings</h2>
      
      {bookings.length === 0 ? (
        <div className="no-bookings">
          <p>You haven't made any bookings yet.</p>
        </div>
      ) : (
        <div className="bookings-grid">
          {bookings.map((booking) => (
            <div key={booking.id} className="booking-card">
              <div className="booking-header">
                <h3>{booking.house?.title || 'House'}</h3>
                <span className={`status ${getStatusClass(booking.status)}`}>
                  {getStatusText(booking.status)}
                </span>
              </div>
              
              <div className="booking-details">
                <p><strong>Check-in:</strong> {formatDate(booking.checkInDate)}</p>
                <p><strong>Check-out:</strong> {formatDate(booking.checkOutDate)}</p>
                <p><strong>Guests:</strong> {booking.numberOfGuests}</p>
                <p><strong>Total Amount:</strong> ${booking.totalAmount}</p>
                {booking.specialRequests && (
                  <p><strong>Special Requests:</strong> {booking.specialRequests}</p>
                )}
              </div>
              
              <div className="booking-footer">
                <p className="booking-date">
                  Booked on {formatDate(booking.createdAt)}
                </p>
              </div>
            </div>
          ))}
        </div>
      )}
    </div>
  );
};

export default BookingList;