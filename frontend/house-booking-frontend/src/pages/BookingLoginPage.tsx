import React, { useState } from 'react';
import { useNavigate, Link } from 'react-router-dom';
import { useAuth } from '../contexts/AuthContext';
import '../styles/booking.css';

const BookingLoginPage: React.FC = () => {
  const navigate = useNavigate();
  const { login, isLoading, error, clearError } = useAuth();
  const [formData, setFormData] = useState({
    email: '',
    password: '',
  });
  const [formErrors, setFormErrors] = useState<{ [key: string]: string }>({});

  const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;
    setFormData(prev => ({ ...prev, [name]: value }));
    
    // Clear field error when user starts typing
    if (formErrors[name]) {
      setFormErrors(prev => ({ ...prev, [name]: '' }));
    }
    
    // Clear general error
    if (error) {
      clearError();
    }
  };

  const validateForm = () => {
    const errors: { [key: string]: string } = {};

    if (!formData.email.trim()) {
      errors.email = 'E-posta adresi gerekli';
    } else if (!/^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(formData.email)) {
      errors.email = 'Geçerli bir e-posta adresi girin';
    }

    if (!formData.password.trim()) {
      errors.password = 'Şifre gerekli';
    }

    setFormErrors(errors);
    return Object.keys(errors).length === 0;
  };

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    
    if (!validateForm()) {
      return;
    }

    try {
      await login(formData.email, formData.password);
      // Redirect to previous page or home
      const redirectTo = new URLSearchParams(window.location.search).get('redirect') || '/';
      navigate(redirectTo);
    } catch (error) {
      // Error is handled by AuthContext
      console.error('Login failed:', error);
    }
  };

  return (
    <div className="booking-app">
      {/* Header */}
      <header className="booking-header">
        <div className="header-container">
          <a href="/" className="logo">
            <div className="logo-icon">🏨</div>
            <span>StayBooking</span>
          </a>
          
          <nav className="header-nav">
            <button className="nav-link" onClick={() => navigate('/')}>
              ← Ana Sayfa
            </button>
          </nav>
          
          <div className="header-actions">
            <Link to="/register" className="btn btn-outline">
              Üye Ol
            </Link>
          </div>
        </div>
      </header>

      {/* Login Form */}
      <div style={{ 
        minHeight: 'calc(100vh - 70px)',
        background: 'linear-gradient(135deg, var(--primary-blue-light) 0%, var(--background-white) 100%)',
        display: 'flex',
        alignItems: 'center',
        justifyContent: 'center',
        padding: '40px 20px'
      }}>
        <div style={{
          background: 'white',
          borderRadius: '16px',
          boxShadow: 'var(--shadow-medium)',
          padding: '48px',
          width: '100%',
          maxWidth: '440px'
        }}>
          <div style={{ textAlign: 'center', marginBottom: '32px' }}>
            <h1 style={{ 
              fontSize: '32px', 
              fontWeight: '700', 
              color: 'var(--text-dark)',
              marginBottom: '8px'
            }}>
              Hoş Geldiniz
            </h1>
            <p style={{ 
              color: 'var(--text-medium)', 
              fontSize: '16px'
            }}>
              Hesabınıza giriş yapın
            </p>
          </div>

          {error && (
            <div style={{
              background: '#fee2e2',
              border: '1px solid #fecaca',
              color: '#dc2626',
              padding: '12px 16px',
              borderRadius: 'var(--border-radius)',
              marginBottom: '24px',
              fontSize: '14px',
              display: 'flex',
              alignItems: 'center',
              gap: '8px'
            }}>
              <span>⚠️</span>
              {error}
            </div>
          )}

          <form onSubmit={handleSubmit} style={{ display: 'flex', flexDirection: 'column', gap: '24px' }}>
            <div>
              <label style={{
                display: 'block',
                fontSize: '14px',
                fontWeight: '600',
                color: 'var(--text-dark)',
                marginBottom: '8px'
              }}>
                E-posta Adresi
              </label>
              <input
                type="email"
                name="email"
                value={formData.email}
                onChange={handleChange}
                style={{
                  width: '100%',
                  padding: '12px 16px',
                  border: `1px solid ${formErrors.email ? '#dc2626' : 'var(--border-light)'}`,
                  borderRadius: 'var(--border-radius)',
                  fontSize: '16px',
                  background: 'var(--background-white)',
                  transition: 'border-color 0.2s',
                  outline: 'none'
                }}
                placeholder="ornek@email.com"
                onFocus={(e) => e.target.style.borderColor = 'var(--primary-blue)'}
                onBlur={(e) => e.target.style.borderColor = formErrors.email ? '#dc2626' : 'var(--border-light)'}
              />
              {formErrors.email && (
                <p style={{ color: '#dc2626', fontSize: '12px', marginTop: '4px' }}>
                  {formErrors.email}
                </p>
              )}
            </div>

            <div>
              <label style={{
                display: 'block',
                fontSize: '14px',
                fontWeight: '600',
                color: 'var(--text-dark)',
                marginBottom: '8px'
              }}>
                Şifre
              </label>
              <input
                type="password"
                name="password"
                value={formData.password}
                onChange={handleChange}
                style={{
                  width: '100%',
                  padding: '12px 16px',
                  border: `1px solid ${formErrors.password ? '#dc2626' : 'var(--border-light)'}`,
                  borderRadius: 'var(--border-radius)',
                  fontSize: '16px',
                  background: 'var(--background-white)',
                  transition: 'border-color 0.2s',
                  outline: 'none'
                }}
                placeholder="••••••••"
                onFocus={(e) => e.target.style.borderColor = 'var(--primary-blue)'}
                onBlur={(e) => e.target.style.borderColor = formErrors.password ? '#dc2626' : 'var(--border-light)'}
              />
              {formErrors.password && (
                <p style={{ color: '#dc2626', fontSize: '12px', marginTop: '4px' }}>
                  {formErrors.password}
                </p>
              )}
            </div>

            <button
              type="submit"
              disabled={isLoading}
              className="btn btn-primary"
              style={{
                width: '100%',
                padding: '16px',
                fontSize: '16px',
                fontWeight: '600',
                marginTop: '8px',
                opacity: isLoading ? '0.7' : '1',
                cursor: isLoading ? 'not-allowed' : 'pointer'
              }}
            >
              {isLoading ? (
                <div style={{ display: 'flex', alignItems: 'center', justifyContent: 'center', gap: '8px' }}>
                  <div style={{
                    width: '16px',
                    height: '16px',
                    border: '2px solid rgba(255,255,255,0.3)',
                    borderTop: '2px solid white',
                    borderRadius: '50%',
                    animation: 'spin 1s linear infinite'
                  }}></div>
                  Giriş Yapılıyor...
                </div>
              ) : (
                'Giriş Yap'
              )}
            </button>
          </form>

          <div style={{
            textAlign: 'center',
            marginTop: '32px',
            paddingTop: '24px',
            borderTop: '1px solid var(--border-light)'
          }}>
            <p style={{ color: 'var(--text-medium)', fontSize: '14px' }}>
              Hesabınız yok mu?{' '}
              <Link 
                to="/register" 
                style={{ 
                  color: 'var(--primary-blue)', 
                  textDecoration: 'none',
                  fontWeight: '600'
                }}
              >
                Üye Olun
              </Link>
            </p>
          </div>

          <div style={{ textAlign: 'center', marginTop: '16px' }}>
            <a 
              href="#" 
              style={{ 
                color: 'var(--text-medium)', 
                fontSize: '14px',
                textDecoration: 'none'
              }}
            >
              Şifrenizi mi unuttunuz?
            </a>
          </div>
        </div>
      </div>

      <style jsx>{`
        @keyframes spin {
          0% { transform: rotate(0deg); }
          100% { transform: rotate(360deg); }
        }
      `}</style>
    </div>
  );
};

export default BookingLoginPage;