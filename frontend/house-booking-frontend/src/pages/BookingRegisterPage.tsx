import React, { useState } from 'react';
import { useNavigate, Link } from 'react-router-dom';
import { useAuth } from '../contexts/AuthContext';
import '../styles/booking.css';

const BookingRegisterPage: React.FC = () => {
  const navigate = useNavigate();
  const { register, isLoading, error, clearError } = useAuth();
  const [formData, setFormData] = useState({
    firstName: '',
    lastName: '',
    email: '',
    password: '',
    confirmPassword: '',
  });
  const [formErrors, setFormErrors] = useState<{ [key: string]: string }>({});
  const [showSuccess, setShowSuccess] = useState(false);

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

    if (!formData.firstName.trim()) {
      errors.firstName = 'Ad gerekli';
    } else if (formData.firstName.length > 50) {
      errors.firstName = 'Ad en fazla 50 karakter olabilir';
    }

    if (!formData.lastName.trim()) {
      errors.lastName = 'Soyad gerekli';
    } else if (formData.lastName.length > 50) {
      errors.lastName = 'Soyad en fazla 50 karakter olabilir';
    }

    if (!formData.email.trim()) {
      errors.email = 'E-posta adresi gerekli';
    } else if (!/^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(formData.email)) {
      errors.email = 'Geçerli bir e-posta adresi girin';
    } else if (formData.email.length > 200) {
      errors.email = 'E-posta adresi en fazla 200 karakter olabilir';
    }

    if (!formData.password.trim()) {
      errors.password = 'Şifre gerekli';
    } else if (formData.password.length < 8 || formData.password.length > 100) {
      errors.password = 'Şifre 8-100 karakter arasında olmalı';
    } else if (!/^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]/.test(formData.password)) {
      errors.password = 'Şifre en az 1 büyük harf, 1 küçük harf, 1 rakam ve 1 özel karakter içermeli (@$!%*?&)';
    }

    if (!formData.confirmPassword.trim()) {
      errors.confirmPassword = 'Şifre tekrarı gerekli';
    } else if (formData.password !== formData.confirmPassword) {
      errors.confirmPassword = 'Şifreler eşleşmiyor';
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
      await register(formData.email, formData.password, formData.firstName, formData.lastName);
      setShowSuccess(true);
      
      // Redirect to login after 3 seconds
      setTimeout(() => {
        navigate('/login');
      }, 3000);
    } catch (error) {
      // Error is handled by AuthContext
      console.error('Registration failed:', error);
    }
  };

  if (showSuccess) {
    return (
      <div className="booking-app">
        <header className="booking-header">
          <div className="header-container">
            <a href="/" className="logo">
              <div className="logo-icon">🏨</div>
              <span>StayBooking</span>
            </a>
          </div>
        </header>

        <div style={{ 
          minHeight: 'calc(100vh - 70px)',
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
            maxWidth: '440px',
            textAlign: 'center'
          }}>
            <div style={{ 
              fontSize: '64px', 
              marginBottom: '24px' 
            }}>
              ✅
            </div>
            <h1 style={{ 
              fontSize: '28px', 
              fontWeight: '700', 
              color: 'var(--text-dark)',
              marginBottom: '16px'
            }}>
              Kayıt Başarılı!
            </h1>
            <p style={{ 
              color: 'var(--text-medium)', 
              fontSize: '16px',
              marginBottom: '24px',
              lineHeight: '1.5'
            }}>
              Hesabınız başarıyla oluşturuldu. Artık giriş yaparak konaklama rezervasyonları yapabilirsiniz.
            </p>
            <p style={{ 
              color: 'var(--text-light)', 
              fontSize: '14px',
              marginBottom: '24px'
            }}>
              3 saniye içinde giriş sayfasına yönlendirileceksiniz...
            </p>
            <Link to="/login" className="btn btn-primary">
              Hemen Giriş Yap
            </Link>
          </div>
        </div>
      </div>
    );
  }

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
            <Link to="/login" className="btn btn-outline">
              Giriş Yap
            </Link>
          </div>
        </div>
      </header>

      {/* Register Form */}
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
              Üye Olun
            </h1>
            <p style={{ 
              color: 'var(--text-medium)', 
              fontSize: '16px'
            }}>
              Hesap oluşturun ve rezervasyon yapmaya başlayın
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

          <form onSubmit={handleSubmit} style={{ display: 'flex', flexDirection: 'column', gap: '20px' }}>
            <div style={{ display: 'grid', gridTemplateColumns: '1fr 1fr', gap: '16px' }}>
              <div>
                <label style={{
                  display: 'block',
                  fontSize: '14px',
                  fontWeight: '600',
                  color: 'var(--text-dark)',
                  marginBottom: '8px'
                }}>
                  Ad
                </label>
                <input
                  type="text"
                  name="firstName"
                  value={formData.firstName}
                  onChange={handleChange}
                  style={{
                    width: '100%',
                    padding: '12px 16px',
                    border: `1px solid ${formErrors.firstName ? '#dc2626' : 'var(--border-light)'}`,
                    borderRadius: 'var(--border-radius)',
                    fontSize: '16px',
                    background: 'var(--background-white)',
                    transition: 'border-color 0.2s',
                    outline: 'none'
                  }}
                  placeholder="Adınız"
                  onFocus={(e) => e.target.style.borderColor = 'var(--primary-blue)'}
                  onBlur={(e) => e.target.style.borderColor = formErrors.firstName ? '#dc2626' : 'var(--border-light)'}
                />
                {formErrors.firstName && (
                  <p style={{ color: '#dc2626', fontSize: '12px', marginTop: '4px' }}>
                    {formErrors.firstName}
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
                  Soyad
                </label>
                <input
                  type="text"
                  name="lastName"
                  value={formData.lastName}
                  onChange={handleChange}
                  style={{
                    width: '100%',
                    padding: '12px 16px',
                    border: `1px solid ${formErrors.lastName ? '#dc2626' : 'var(--border-light)'}`,
                    borderRadius: 'var(--border-radius)',
                    fontSize: '16px',
                    background: 'var(--background-white)',
                    transition: 'border-color 0.2s',
                    outline: 'none'
                  }}
                  placeholder="Soyadınız"
                  onFocus={(e) => e.target.style.borderColor = 'var(--primary-blue)'}
                  onBlur={(e) => e.target.style.borderColor = formErrors.lastName ? '#dc2626' : 'var(--border-light)'}
                />
                {formErrors.lastName && (
                  <p style={{ color: '#dc2626', fontSize: '12px', marginTop: '4px' }}>
                    {formErrors.lastName}
                  </p>
                )}
              </div>
            </div>

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
                <p style={{ color: '#dc2626', fontSize: '12px', marginTop: '4px', lineHeight: '1.4' }}>
                  {formErrors.password}
                </p>
              )}
              <p style={{ color: 'var(--text-light)', fontSize: '12px', marginTop: '4px', lineHeight: '1.4' }}>
                En az 8 karakter, 1 büyük harf, 1 küçük harf, 1 rakam ve 1 özel karakter (@$!%*?&)
              </p>
            </div>

            <div>
              <label style={{
                display: 'block',
                fontSize: '14px',
                fontWeight: '600',
                color: 'var(--text-dark)',
                marginBottom: '8px'
              }}>
                Şifre Tekrarı
              </label>
              <input
                type="password"
                name="confirmPassword"
                value={formData.confirmPassword}
                onChange={handleChange}
                style={{
                  width: '100%',
                  padding: '12px 16px',
                  border: `1px solid ${formErrors.confirmPassword ? '#dc2626' : 'var(--border-light)'}`,
                  borderRadius: 'var(--border-radius)',
                  fontSize: '16px',
                  background: 'var(--background-white)',
                  transition: 'border-color 0.2s',
                  outline: 'none'
                }}
                placeholder="••••••••"
                onFocus={(e) => e.target.style.borderColor = 'var(--primary-blue)'}
                onBlur={(e) => e.target.style.borderColor = formErrors.confirmPassword ? '#dc2626' : 'var(--border-light)'}
              />
              {formErrors.confirmPassword && (
                <p style={{ color: '#dc2626', fontSize: '12px', marginTop: '4px' }}>
                  {formErrors.confirmPassword}
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
                  Hesap Oluşturuluyor...
                </div>
              ) : (
                'Hesap Oluştur'
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
              Zaten hesabınız var mı?{' '}
              <Link 
                to="/login" 
                style={{ 
                  color: 'var(--primary-blue)', 
                  textDecoration: 'none',
                  fontWeight: '600'
                }}
              >
                Giriş Yapın
              </Link>
            </p>
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

export default BookingRegisterPage;