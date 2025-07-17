import React, { useState, useEffect } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import { api } from '../services/api';

interface Review {
  id: string;
  userId: string;
  propertyId: string;
  rating: number;
  comment: string;
  isVerified: boolean;
  isVisible: boolean;
  isDeleted: boolean;
  isInappropriate: boolean;
  createdAt: string;
}

const ReviewsPage: React.FC = () => {
  const { propertyId } = useParams<{ propertyId: string }>();
  const navigate = useNavigate();
  const [reviews, setReviews] = useState<Review[]>([]);
  const [loading, setLoading] = useState(true);
  const [filters, setFilters] = useState({
    isVerified: null as boolean | null,
    isVisible: true,
    isDeleted: false,
    isInappropriate: false,
    minRating: 1,
    maxRating: 5
  });
  const [editingReview, setEditingReview] = useState<Review | null>(null);
  const [editComment, setEditComment] = useState('');

  useEffect(() => {
    if (propertyId) {
      fetchReviews();
    }
  }, [propertyId, filters]);

  const fetchReviews = async () => {
    try {
      setLoading(true);
      const params = new URLSearchParams();
      params.append('propertyId', propertyId!);
      params.append('pageSize', '50');
      
      if (filters.isVerified !== null) params.append('isVerified', filters.isVerified.toString());
      if (filters.isVisible !== null) params.append('isVisible', filters.isVisible.toString());
      if (filters.isDeleted !== null) params.append('isDeleted', filters.isDeleted.toString());
      if (filters.isInappropriate !== null) params.append('isInappropriate', filters.isInappropriate.toString());
      if (filters.minRating) params.append('minRating', filters.minRating.toString());
      if (filters.maxRating) params.append('maxRating', filters.maxRating.toString());

      const response = await api.get(`/reviews?${params.toString()}`);
      setReviews(response.data.items || []);
    } catch (error) {
      console.error('Error fetching reviews:', error);
    } finally {
      setLoading(false);
    }
  };

  const handleDeleteReview = async (reviewId: string) => {
    try {
      await api.delete(`/reviews/${reviewId}`);
      fetchReviews();
    } catch (error) {
      console.error('Error deleting review:', error);
    }
  };

  const handleMarkInappropriate = async (reviewId: string) => {
    try {
      await api.post(`/reviews/${reviewId}/mark-inappropriate`);
      fetchReviews();
    } catch (error) {
      console.error('Error marking review as inappropriate:', error);
    }
  };

  const handleEditComment = (review: Review) => {
    setEditingReview(review);
    setEditComment(review.comment);
  };

  const handleSaveComment = async () => {
    if (!editingReview) return;

    try {
      await api.put(`/reviews/${editingReview.id}/comment`, {
        comment: editComment
      });
      setEditingReview(null);
      setEditComment('');
      fetchReviews();
    } catch (error) {
      console.error('Error updating comment:', error);
    }
  };

  const renderStars = (rating: number) => {
    return '⭐'.repeat(rating) + '☆'.repeat(5 - rating);
  };

  const formatDate = (dateString: string) => {
    return new Date(dateString).toLocaleDateString();
  };

  return (
    <div className="reviews-page">
      <div className="page-header">
        <button 
          className="btn btn-outline"
          onClick={() => navigate(`/properties/${propertyId}`)}
        >
          ← Back to Property
        </button>
        <h1>⭐ Reviews Management</h1>
      </div>

      <div className="filters-section">
        <div className="filters">
          <select
            value={filters.isVerified?.toString() || ''}
            onChange={(e) => setFilters({
              ...filters, 
              isVerified: e.target.value === '' ? null : e.target.value === 'true'
            })}
            className="filter-select"
          >
            <option value="">All Reviews</option>
            <option value="true">Verified Only</option>
            <option value="false">Unverified Only</option>
          </select>

          <select
            value={filters.isVisible.toString()}
            onChange={(e) => setFilters({...filters, isVisible: e.target.value === 'true'})}
            className="filter-select"
          >
            <option value="true">Visible</option>
            <option value="false">Hidden</option>
          </select>

          <select
            value={filters.isInappropriate.toString()}
            onChange={(e) => setFilters({...filters, isInappropriate: e.target.value === 'true'})}
            className="filter-select"
          >
            <option value="false">Appropriate</option>
            <option value="true">Inappropriate</option>
          </select>

          <div className="rating-filter">
            <label>Rating:</label>
            <select
              value={filters.minRating}
              onChange={(e) => setFilters({...filters, minRating: parseInt(e.target.value)})}
              className="filter-select"
            >
              <option value={1}>1+ Stars</option>
              <option value={2}>2+ Stars</option>
              <option value={3}>3+ Stars</option>
              <option value={4}>4+ Stars</option>
              <option value={5}>5 Stars</option>
            </select>
          </div>
        </div>
      </div>

      {loading ? (
        <div className="loading">Loading reviews...</div>
      ) : (
        <div className="reviews-list">
          {reviews.map((review) => (
            <div key={review.id} className="review-card">
              <div className="review-header">
                <div className="review-rating">
                  {renderStars(review.rating)}
                  <span className="rating-number">({review.rating}/5)</span>
                </div>
                <div className="review-date">
                  {formatDate(review.createdAt)}
                </div>
              </div>

              <div className="review-content">
                {editingReview?.id === review.id ? (
                  <textarea
                    value={editComment}
                    onChange={(e) => setEditComment(e.target.value)}
                    className="edit-comment-textarea"
                    rows={4}
                  />
                ) : (
                  <p className="review-comment">{review.comment}</p>
                )}
              </div>

              <div className="review-meta">
                <div className="review-badges">
                  {review.isVerified && <span className="badge verified">✅ Verified</span>}
                  {review.isInappropriate && <span className="badge inappropriate">🚫 Inappropriate</span>}
                  {!review.isVisible && <span className="badge hidden">👁️ Hidden</span>}
                  {review.isDeleted && <span className="badge deleted">🗑️ Deleted</span>}
                </div>
              </div>

              <div className="review-actions">
                {editingReview?.id === review.id ? (
                  <div className="edit-actions">
                    <button 
                      className="btn btn-outline"
                      onClick={() => setEditingReview(null)}
                    >
                      Cancel
                    </button>
                    <button 
                      className="btn btn-success"
                      onClick={handleSaveComment}
                    >
                      💾 Save
                    </button>
                  </div>
                ) : (
                  <>
                    <button 
                      className="btn btn-outline"
                      onClick={() => handleEditComment(review)}
                    >
                      ✏️ Edit Comment
                    </button>
                    {!review.isInappropriate && (
                      <button 
                        className="btn btn-warning"
                        onClick={() => handleMarkInappropriate(review.id)}
                      >
                        🚫 Mark Inappropriate
                      </button>
                    )}
                    <button 
                      className="btn btn-danger"
                      onClick={() => handleDeleteReview(review.id)}
                    >
                      🗑️ Delete
                    </button>
                  </>
                )}
              </div>
            </div>
          ))}
        </div>
      )}

      {!loading && reviews.length === 0 && (
        <div className="no-results">
          <p>No reviews found for this property.</p>
        </div>
      )}
    </div>
  );
};

export default ReviewsPage;