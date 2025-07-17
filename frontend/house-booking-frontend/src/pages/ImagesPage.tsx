import React, { useState, useEffect } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import { api } from '../services/api';

interface Image {
  id: string;
  url: string;
  alt: string;
  isPrimary: boolean;
  order: number;
  isDeleted: boolean;
  createdAt: string;
}

const ImagesPage: React.FC = () => {
  const { propertyId } = useParams<{ propertyId: string }>();
  const navigate = useNavigate();
  const [images, setImages] = useState<Image[]>([]);
  const [loading, setLoading] = useState(true);
  const [showUploadForm, setShowUploadForm] = useState(false);
  const [uploadForm, setUploadForm] = useState({
    url: '',
    alt: '',
    isPrimary: false,
    order: 0
  });

  useEffect(() => {
    fetchImages();
  }, []);

  const fetchImages = async () => {
    try {
      setLoading(true);
      // Note: This is a simplified approach since the backend doesn't have a direct endpoint
      // to get images by property. In a real implementation, you'd need to modify the backend
      // or use a different approach to fetch property images.
      setImages([]);
    } catch (error) {
      console.error('Error fetching images:', error);
    } finally {
      setLoading(false);
    }
  };

  const handleCreateImage = async () => {
    try {
      const response = await api.post('/images', {
        url: uploadForm.url,
        alt: uploadForm.alt,
        isPrimary: uploadForm.isPrimary,
        order: uploadForm.order
      });
      
      setImages([...images, response.data]);
      setShowUploadForm(false);
      setUploadForm({ url: '', alt: '', isPrimary: false, order: 0 });
    } catch (error) {
      console.error('Error creating image:', error);
    }
  };

  const handleSetAsPrimary = async (imageId: string) => {
    try {
      await api.post(`/images/${imageId}/set-primary`);
      // Update the images state to reflect the change
      setImages(images.map(img => ({
        ...img,
        isPrimary: img.id === imageId
      })));
    } catch (error) {
      console.error('Error setting image as primary:', error);
    }
  };

  const handleMarkForDeletion = async (imageId: string) => {
    try {
      await api.post(`/images/${imageId}/mark-for-deletion`);
      setImages(images.map(img => 
        img.id === imageId ? { ...img, isDeleted: true } : img
      ));
    } catch (error) {
      console.error('Error marking image for deletion:', error);
    }
  };

  const handleFileUpload = (event: React.ChangeEvent<HTMLInputElement>) => {
    const file = event.target.files?.[0];
    if (file) {
      // In a real implementation, you would upload the file to a storage service
      // and get back a URL. For now, we'll use a placeholder URL.
      const objectURL = URL.createObjectURL(file);
      setUploadForm({ ...uploadForm, url: objectURL });
    }
  };

  return (
    <div className="images-page">
      <div className="page-header">
        <button 
          className="btn btn-outline"
          onClick={() => navigate(`/properties/${propertyId}`)}
        >
          ← Back to Property
        </button>
        <h1>🖼️ Images Management</h1>
        <button 
          className="btn btn-primary"
          onClick={() => setShowUploadForm(true)}
        >
          ➕ Add Image
        </button>
      </div>

      {loading ? (
        <div className="loading">Loading images...</div>
      ) : (
        <div className="images-grid">
          {images.map((image) => (
            <div key={image.id} className="image-card">
              <div className="image-container">
                <img 
                  src={image.url} 
                  alt={image.alt}
                  className="property-image"
                />
                {image.isPrimary && (
                  <div className="primary-badge">
                    ⭐ Primary
                  </div>
                )}
                {image.isDeleted && (
                  <div className="deleted-overlay">
                    🗑️ Marked for Deletion
                  </div>
                )}
              </div>
              
              <div className="image-info">
                <div className="image-alt">
                  {image.alt || 'No description'}
                </div>
                <div className="image-order">
                  Order: {image.order}
                </div>
              </div>

              <div className="image-actions">
                {!image.isPrimary && !image.isDeleted && (
                  <button 
                    className="btn btn-success"
                    onClick={() => handleSetAsPrimary(image.id)}
                  >
                    ⭐ Set as Primary
                  </button>
                )}
                
                {!image.isDeleted && (
                  <button 
                    className="btn btn-danger"
                    onClick={() => handleMarkForDeletion(image.id)}
                  >
                    🗑️ Delete
                  </button>
                )}
              </div>
            </div>
          ))}
        </div>
      )}

      {!loading && images.length === 0 && (
        <div className="no-results">
          <p>No images found for this property.</p>
          <button 
            className="btn btn-primary"
            onClick={() => setShowUploadForm(true)}
          >
            ➕ Add First Image
          </button>
        </div>
      )}

      {showUploadForm && (
        <div className="modal-overlay">
          <div className="modal">
            <div className="modal-header">
              <h2>Upload New Image</h2>
              <button 
                className="btn btn-text"
                onClick={() => setShowUploadForm(false)}
              >
                ✕
              </button>
            </div>
            
            <div className="modal-content">
              <div className="form-group">
                <label>Upload Image:</label>
                <input
                  type="file"
                  accept="image/*"
                  onChange={handleFileUpload}
                  className="form-input"
                />
              </div>

              <div className="form-group">
                <label>Image URL (Alternative):</label>
                <input
                  type="url"
                  value={uploadForm.url}
                  onChange={(e) => setUploadForm({...uploadForm, url: e.target.value})}
                  className="form-input"
                  placeholder="https://example.com/image.jpg"
                />
              </div>

              <div className="form-group">
                <label>Alt Text:</label>
                <input
                  type="text"
                  value={uploadForm.alt}
                  onChange={(e) => setUploadForm({...uploadForm, alt: e.target.value})}
                  className="form-input"
                  placeholder="Description of the image"
                />
              </div>

              <div className="form-group">
                <label>Display Order:</label>
                <input
                  type="number"
                  value={uploadForm.order}
                  onChange={(e) => setUploadForm({...uploadForm, order: parseInt(e.target.value)})}
                  className="form-input"
                  min="0"
                />
              </div>

              <div className="form-group">
                <label className="checkbox-label">
                  <input
                    type="checkbox"
                    checked={uploadForm.isPrimary}
                    onChange={(e) => setUploadForm({...uploadForm, isPrimary: e.target.checked})}
                  />
                  Set as Primary Image
                </label>
              </div>

              {uploadForm.url && (
                <div className="image-preview">
                  <img 
                    src={uploadForm.url} 
                    alt="Preview"
                    className="preview-image"
                  />
                </div>
              )}
            </div>

            <div className="modal-actions">
              <button 
                className="btn btn-outline"
                onClick={() => setShowUploadForm(false)}
              >
                Cancel
              </button>
              <button 
                className="btn btn-success"
                onClick={handleCreateImage}
                disabled={!uploadForm.url}
              >
                📁 Upload Image
              </button>
            </div>
          </div>
        </div>
      )}
    </div>
  );
};

export default ImagesPage;