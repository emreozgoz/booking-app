import React from 'react';
import { BrowserRouter as Router, Routes, Route, Navigate } from 'react-router-dom';
import HomePage from './pages/HomePage';
import PropertiesPage from './pages/PropertiesPage';
import PropertyDetailsPage from './pages/PropertyDetailsPage';
import RoomsPage from './pages/RoomsPage';
import ReviewsPage from './pages/ReviewsPage';
import PaymentsPage from './pages/PaymentsPage';
import ImagesPage from './pages/ImagesPage';
import './App.css';
import './styles/booking-site.css';
import './styles/pages.css';

function App() {
  return (
    <Router>
      <div className="app">
        <header className="app-header">
          <h1>🏠 BookingApp Management</h1>
          <nav className="app-nav">
            <a href="/" className="nav-link">🏠 Home</a>
            <a href="/properties" className="nav-link">🏨 Properties</a>
            <a href="/payments" className="nav-link">💳 Payments</a>
          </nav>
        </header>

        <main className="app-main">
          <Routes>
            <Route path="/" element={<HomePage />} />
            <Route path="/properties" element={<PropertiesPage />} />
            <Route path="/properties/:id" element={<PropertyDetailsPage />} />
            <Route path="/properties/:propertyId/rooms" element={<RoomsPage />} />
            <Route path="/properties/:propertyId/reviews" element={<ReviewsPage />} />
            <Route path="/properties/:propertyId/images" element={<ImagesPage />} />
            <Route path="/payments" element={<PaymentsPage />} />
            <Route path="*" element={<Navigate to="/" replace />} />
          </Routes>
        </main>
      </div>
    </Router>
  );
}

export default App;
