import { BrowserRouter as Router, Routes, Route, Navigate } from 'react-router-dom';
import AirbnbHomePage from './pages/AirbnbHomePage';
import PropertyDetailPage from './pages/PropertyDetailPage';
import PropertiesPage from './pages/PropertiesPage';
import PropertyDetailsPage from './pages/PropertyDetailsPage';
import RoomsPage from './pages/RoomsPage';
import ReviewsPage from './pages/ReviewsPage';
import PaymentsPage from './pages/PaymentsPage';
import ImagesPage from './pages/ImagesPage';
import './App.css';
import './styles/booking-site.css';
import './styles/pages.css';
import './styles/airbnb.css';

function App() {
  return (
    <Router>
      <Routes>
        {/* Airbnb-style public pages */}
        <Route path="/" element={<AirbnbHomePage />} />
        <Route path="/property/:id" element={<PropertyDetailPage />} />
        
        {/* Admin/Management pages */}
        <Route path="/admin" element={<PropertiesPage />} />
        <Route path="/admin/properties" element={<PropertiesPage />} />
        <Route path="/admin/properties/:id" element={<PropertyDetailsPage />} />
        <Route path="/admin/properties/:propertyId/rooms" element={<RoomsPage />} />
        <Route path="/admin/properties/:propertyId/reviews" element={<ReviewsPage />} />
        <Route path="/admin/properties/:propertyId/images" element={<ImagesPage />} />
        <Route path="/admin/payments" element={<PaymentsPage />} />
        
        <Route path="*" element={<Navigate to="/" replace />} />
      </Routes>
    </Router>
  );
}

export default App;
