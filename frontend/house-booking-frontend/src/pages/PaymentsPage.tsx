import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import { api } from '../services/api';

interface Payment {
  id: string;
  reservationId: string;
  amount: {
    amount: number;
    currency: string;
  };
  status: 'Pending' | 'Completed' | 'Failed' | 'Refunded';
  method: 'CreditCard' | 'PayPal' | 'BankTransfer' | 'Cryptocurrency';
  transactionId?: string;
  createdAt: string;
  completedAt?: string;
}

const PaymentsPage: React.FC = () => {
  const navigate = useNavigate();
  const [payments, setPayments] = useState<Payment[]>([]);
  const [loading, setLoading] = useState(true);
  const [filters, setFilters] = useState({
    status: '' as Payment['status'] | '',
    method: '' as Payment['method'] | '',
    fromDate: '',
    toDate: ''
  });
  const [selectedPayment, setSelectedPayment] = useState<Payment | null>(null);
  const [actionType, setActionType] = useState<'success' | 'fail' | 'refund' | null>(null);
  const [actionData, setActionData] = useState({
    transactionId: '',
    reason: ''
  });

  useEffect(() => {
    fetchPayments();
  }, [filters]);

  const fetchPayments = async () => {
    try {
      setLoading(true);
      const params = new URLSearchParams();
      params.append('pageSize', '50');
      
      if (filters.status) params.append('status', filters.status);
      if (filters.method) params.append('method', filters.method);
      if (filters.fromDate) params.append('fromDate', filters.fromDate);
      if (filters.toDate) params.append('toDate', filters.toDate);

      const response = await api.get(`/payments?${params.toString()}`);
      setPayments(response.data.items || []);
    } catch (error) {
      console.error('Error fetching payments:', error);
    } finally {
      setLoading(false);
    }
  };

  const handleMarkAsSuccessful = async (paymentId: string, transactionId: string) => {
    try {
      await api.post(`/payments/${paymentId}/mark-successful`, { transactionId });
      fetchPayments();
      setSelectedPayment(null);
      setActionType(null);
      setActionData({ transactionId: '', reason: '' });
    } catch (error) {
      console.error('Error marking payment as successful:', error);
    }
  };

  const handleMarkAsFailed = async (paymentId: string, reason: string) => {
    try {
      await api.post(`/payments/${paymentId}/mark-failed`, { reason });
      fetchPayments();
      setSelectedPayment(null);
      setActionType(null);
      setActionData({ transactionId: '', reason: '' });
    } catch (error) {
      console.error('Error marking payment as failed:', error);
    }
  };

  const handleRefundPayment = async (paymentId: string, reason: string) => {
    try {
      await api.post(`/payments/${paymentId}/refund`, { reason });
      fetchPayments();
      setSelectedPayment(null);
      setActionType(null);
      setActionData({ transactionId: '', reason: '' });
    } catch (error) {
      console.error('Error refunding payment:', error);
    }
  };

  const handleAction = () => {
    if (!selectedPayment) return;

    switch (actionType) {
      case 'success':
        handleMarkAsSuccessful(selectedPayment.id, actionData.transactionId);
        break;
      case 'fail':
        handleMarkAsFailed(selectedPayment.id, actionData.reason);
        break;
      case 'refund':
        handleRefundPayment(selectedPayment.id, actionData.reason);
        break;
    }
  };

  const getStatusColor = (status: Payment['status']) => {
    switch (status) {
      case 'Pending': return 'orange';
      case 'Completed': return 'green';
      case 'Failed': return 'red';
      case 'Refunded': return 'blue';
      default: return 'gray';
    }
  };

  const getStatusIcon = (status: Payment['status']) => {
    switch (status) {
      case 'Pending': return '⏳';
      case 'Completed': return '✅';
      case 'Failed': return '❌';
      case 'Refunded': return '🔄';
      default: return '❓';
    }
  };

  const getMethodIcon = (method: Payment['method']) => {
    switch (method) {
      case 'CreditCard': return '💳';
      case 'PayPal': return '🅿️';
      case 'BankTransfer': return '🏦';
      case 'Cryptocurrency': return '₿';
      default: return '💰';
    }
  };

  const formatDate = (dateString: string) => {
    return new Date(dateString).toLocaleDateString();
  };

  const formatDateTime = (dateString: string) => {
    return new Date(dateString).toLocaleString();
  };

  return (
    <div className="payments-page">
      <div className="page-header">
        <h1>💳 Payments Management</h1>
      </div>

      <div className="filters-section">
        <div className="filters">
          <select
            value={filters.status}
            onChange={(e) => setFilters({...filters, status: e.target.value as Payment['status'] | ''})}
            className="filter-select"
          >
            <option value="">All Status</option>
            <option value="Pending">Pending</option>
            <option value="Completed">Completed</option>
            <option value="Failed">Failed</option>
            <option value="Refunded">Refunded</option>
          </select>

          <select
            value={filters.method}
            onChange={(e) => setFilters({...filters, method: e.target.value as Payment['method'] | ''})}
            className="filter-select"
          >
            <option value="">All Methods</option>
            <option value="CreditCard">Credit Card</option>
            <option value="PayPal">PayPal</option>
            <option value="BankTransfer">Bank Transfer</option>
            <option value="Cryptocurrency">Cryptocurrency</option>
          </select>

          <input
            type="date"
            value={filters.fromDate}
            onChange={(e) => setFilters({...filters, fromDate: e.target.value})}
            className="filter-input"
            placeholder="From Date"
          />

          <input
            type="date"
            value={filters.toDate}
            onChange={(e) => setFilters({...filters, toDate: e.target.value})}
            className="filter-input"
            placeholder="To Date"
          />
        </div>
      </div>

      {loading ? (
        <div className="loading">Loading payments...</div>
      ) : (
        <div className="payments-list">
          {payments.map((payment) => (
            <div key={payment.id} className="payment-card">
              <div className="payment-header">
                <div className="payment-amount">
                  {payment.amount.amount} {payment.amount.currency}
                </div>
                <div className={`payment-status ${getStatusColor(payment.status)}`}>
                  {getStatusIcon(payment.status)} {payment.status}
                </div>
              </div>

              <div className="payment-details">
                <div className="payment-info">
                  <span className="payment-method">
                    {getMethodIcon(payment.method)} {payment.method}
                  </span>
                  <span className="payment-date">
                    📅 {formatDateTime(payment.createdAt)}
                  </span>
                  {payment.transactionId && (
                    <span className="transaction-id">
                      🔗 {payment.transactionId}
                    </span>
                  )}
                </div>
                
                <div className="reservation-info">
                  <span className="reservation-id">
                    📋 Reservation: {payment.reservationId}
                  </span>
                </div>
              </div>

              <div className="payment-actions">
                {payment.status === 'Pending' && (
                  <>
                    <button 
                      className="btn btn-success"
                      onClick={() => {
                        setSelectedPayment(payment);
                        setActionType('success');
                      }}
                    >
                      ✅ Mark Successful
                    </button>
                    <button 
                      className="btn btn-danger"
                      onClick={() => {
                        setSelectedPayment(payment);
                        setActionType('fail');
                      }}
                    >
                      ❌ Mark Failed
                    </button>
                  </>
                )}
                
                {payment.status === 'Completed' && (
                  <button 
                    className="btn btn-warning"
                    onClick={() => {
                      setSelectedPayment(payment);
                      setActionType('refund');
                    }}
                  >
                    🔄 Refund
                  </button>
                )}
              </div>
            </div>
          ))}
        </div>
      )}

      {!loading && payments.length === 0 && (
        <div className="no-results">
          <p>No payments found matching your criteria.</p>
        </div>
      )}

      {selectedPayment && actionType && (
        <div className="modal-overlay">
          <div className="modal">
            <div className="modal-header">
              <h2>
                {actionType === 'success' && 'Mark Payment as Successful'}
                {actionType === 'fail' && 'Mark Payment as Failed'}
                {actionType === 'refund' && 'Refund Payment'}
              </h2>
              <button 
                className="btn btn-text"
                onClick={() => {
                  setSelectedPayment(null);
                  setActionType(null);
                  setActionData({ transactionId: '', reason: '' });
                }}
              >
                ✕
              </button>
            </div>
            
            <div className="modal-content">
              <div className="payment-summary">
                <p><strong>Amount:</strong> {selectedPayment.amount.amount} {selectedPayment.amount.currency}</p>
                <p><strong>Method:</strong> {selectedPayment.method}</p>
                <p><strong>Reservation:</strong> {selectedPayment.reservationId}</p>
              </div>

              {actionType === 'success' && (
                <div className="form-group">
                  <label>Transaction ID:</label>
                  <input
                    type="text"
                    value={actionData.transactionId}
                    onChange={(e) => setActionData({...actionData, transactionId: e.target.value})}
                    className="form-input"
                    placeholder="Enter transaction ID"
                  />
                </div>
              )}

              {(actionType === 'fail' || actionType === 'refund') && (
                <div className="form-group">
                  <label>Reason:</label>
                  <textarea
                    value={actionData.reason}
                    onChange={(e) => setActionData({...actionData, reason: e.target.value})}
                    className="form-textarea"
                    rows={3}
                    placeholder="Enter reason..."
                  />
                </div>
              )}
            </div>

            <div className="modal-actions">
              <button 
                className="btn btn-outline"
                onClick={() => {
                  setSelectedPayment(null);
                  setActionType(null);
                  setActionData({ transactionId: '', reason: '' });
                }}
              >
                Cancel
              </button>
              <button 
                className="btn btn-primary"
                onClick={handleAction}
                disabled={
                  (actionType === 'success' && !actionData.transactionId) ||
                  ((actionType === 'fail' || actionType === 'refund') && !actionData.reason)
                }
              >
                Confirm
              </button>
            </div>
          </div>
        </div>
      )}
    </div>
  );
};

export default PaymentsPage;