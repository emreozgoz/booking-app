import React from 'react';
import { useNavigate } from 'react-router-dom';

const HomePage: React.FC = () => {
  const navigate = useNavigate();

  const navigationCards = [
    {
      title: '🏨 Properties',
      description: 'Manage your properties, add new ones, and update existing property information',
      path: '/properties',
      color: 'blue'
    },
    {
      title: '🛏️ Rooms',
      description: 'Manage room availability, pricing, and room information',
      path: '/rooms',
      color: 'green'
    },
    {
      title: '⭐ Reviews',
      description: 'View and manage customer reviews and ratings',
      path: '/reviews',
      color: 'yellow'
    },
    {
      title: '💳 Payments',
      description: 'Track payments, process refunds, and manage payment status',
      path: '/payments',
      color: 'purple'
    },
    {
      title: '🖼️ Images',
      description: 'Upload and manage property images',
      path: '/images',
      color: 'orange'
    }
  ];

  return (
    <div className="home-page">
      <div className="hero-section">
        <h1>🏠 HouseBooking Management</h1>
        <p>Manage your booking business with ease</p>
      </div>

      <div className="navigation-grid">
        {navigationCards.map((card, index) => (
          <div 
            key={index}
            className={`navigation-card ${card.color}`}
            onClick={() => navigate(card.path)}
          >
            <h3>{card.title}</h3>
            <p>{card.description}</p>
            <button className="card-button">
              Get Started →
            </button>
          </div>
        ))}
      </div>

      <div className="stats-section">
        <div className="stat-card">
          <h3>📊 Quick Stats</h3>
          <div className="stats-grid">
            <div className="stat-item">
              <span className="stat-number">-</span>
              <span className="stat-label">Properties</span>
            </div>
            <div className="stat-item">
              <span className="stat-number">-</span>
              <span className="stat-label">Rooms</span>
            </div>
            <div className="stat-item">
              <span className="stat-number">-</span>
              <span className="stat-label">Reviews</span>
            </div>
            <div className="stat-item">
              <span className="stat-number">-</span>
              <span className="stat-label">Payments</span>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default HomePage;