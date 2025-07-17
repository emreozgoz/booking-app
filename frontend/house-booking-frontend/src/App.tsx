import { useState } from 'react';
import type { House, Property } from './types';
import HouseList from './components/HouseList';
import BookingList from './components/BookingList';
import BookingForm from './components/BookingForm';
import PropertyList from './components/PropertyList';
import ReservationForm from './components/ReservationForm';
import './App.css';
import './styles/booking-site.css';

function App() {
  const [activeTab, setActiveTab] = useState<'browse' | 'bookings' | 'properties'>('properties');
  const [selectedHouse, setSelectedHouse] = useState<House | null>(null);
  const [selectedProperty, setSelectedProperty] = useState<Property | null>(null);
  const [showBookingForm, setShowBookingForm] = useState(false);
  const [showReservationForm, setShowReservationForm] = useState(false);

  const handleBookNow = (house: House) => {
    setSelectedHouse(house);
    setShowBookingForm(true);
  };

  const handlePropertyBookNow = (property: Property) => {
    setSelectedProperty(property);
    setShowReservationForm(true);
  };

  const handleCloseBookingForm = () => {
    setShowBookingForm(false);
    setSelectedHouse(null);
  };

  const handleCloseReservationForm = () => {
    setShowReservationForm(false);
    setSelectedProperty(null);
  };

  const handleBookingCreated = () => {
    console.log('Booking created successfully!');
  };

  const handleReservationCreated = () => {
    console.log('Reservation created successfully!');
  };

  return (
    <div className="app">
      <header className="app-header">
        <h1>🏠 BookingApp</h1>
        <nav className="app-nav">
          <button
            className={`nav-btn ${activeTab === 'properties' ? 'active' : ''}`}
            onClick={() => setActiveTab('properties')}
          >
            🏨 Properties
          </button>
          <button
            className={`nav-btn ${activeTab === 'browse' ? 'active' : ''}`}
            onClick={() => setActiveTab('browse')}
          >
            🏠 Houses
          </button>
          <button
            className={`nav-btn ${activeTab === 'bookings' ? 'active' : ''}`}
            onClick={() => setActiveTab('bookings')}
          >
            📋 My Bookings
          </button>
        </nav>
      </header>

      <main className="app-main">
        {activeTab === 'properties' && (
          <PropertyList onBookNow={handlePropertyBookNow} />
        )}
        {activeTab === 'browse' && (
          <HouseList onBookNow={handleBookNow} />
        )}
        {activeTab === 'bookings' && (
          <BookingList />
        )}
      </main>

      {showBookingForm && selectedHouse && (
        <BookingForm
          house={selectedHouse}
          onClose={handleCloseBookingForm}
          onBookingCreated={handleBookingCreated}
        />
      )}
      
      {showReservationForm && selectedProperty && (
        <ReservationForm
          property={selectedProperty}
          onClose={handleCloseReservationForm}
          onReservationCreated={handleReservationCreated}
        />
      )}
    </div>
  );
}

export default App;
