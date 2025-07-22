import { BrowserRouter as Router, Routes, Route, Navigate } from 'react-router-dom';
import { AuthProvider } from './contexts/AuthContext';
import AirbnbHomePage from './pages/AirbnbHomePage';
import BookingHomePage from './pages/BookingHomePage';
import BookingPropertyDetailPage from './pages/BookingPropertyDetailPage';
import BookingLoginPage from './pages/BookingLoginPage';
import BookingRegisterPage from './pages/BookingRegisterPage';
import PropertyDetailPage from './pages/PropertyDetailPage';
import PropertiesPage from './pages/PropertiesPage';
import PropertyDetailsPage from './pages/PropertyDetailsPage';
import RoomsPage from './pages/RoomsPage';
import ReviewsPage from './pages/ReviewsPage';
import PaymentsPage from './pages/PaymentsPage';
import ImagesPage from './pages/ImagesPage';
import LoginPage from './pages/LoginPage';
import RegisterPage from './pages/RegisterPage';
import './App.css';
import './styles/booking-site.css';
import './styles/pages.css';
import './styles/airbnb.css';
import './styles/booking.css';
import './styles/auth.css';

function App() {
  return (
    <AuthProvider>
      <Router>
      <Routes>
        {/* New Authentication pages */}
        <Route path="/login" element={<BookingLoginPage />} />
        <Route path="/register" element={<BookingRegisterPage />} />
        
        {/* Old Authentication pages */}
        <Route path="/old/login" element={<LoginPage />} />
        <Route path="/old/register" element={<RegisterPage />} />
        
        {/* New Booking-style public pages */}
        <Route path="/" element={<BookingHomePage />} />
        <Route path="/property/:id" element={<BookingPropertyDetailPage />} />
        
        {/* Old Airbnb-style public pages */}
        <Route path="/old" element={<AirbnbHomePage />} />
        <Route path="/old/property/:id" element={<PropertyDetailPage />} />
        
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
    </AuthProvider>
  );
}

export default App;
