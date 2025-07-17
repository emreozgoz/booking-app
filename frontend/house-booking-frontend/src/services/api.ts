import axios from "axios";
import type {
  House,
  Booking,
  CreateBookingRequest,
  CreateHouseRequest,
  HouseSearchParams,
  Reservation,
  CreateReservationRequest,
} from "../types";

const API_BASE_URL = "https://localhost:7253/api";

const api = axios.create({
  baseURL: API_BASE_URL,
  headers: {
    "Content-Type": "application/json",
  },
});

export const houseService = {
  getHouses: async (params: HouseSearchParams): Promise<House[]> => {
    const response = await api.get("/houses", { params });
    return response.data;
  },

  getHouseById: async (id: string): Promise<House> => {
    const response = await api.get(`/houses/${id}`);
    return response.data;
  },

  createHouse: async (house: CreateHouseRequest): Promise<House> => {
    const response = await api.post("/houses", house);
    return response.data;
  },
};

export const bookingService = {
  getBookingsByUser: async (userId: string): Promise<Booking[]> => {
    const response = await api.get(`/bookings/user/${userId}`);
    return response.data;
  },

  createBooking: async (booking: CreateBookingRequest): Promise<Booking> => {
    const response = await api.post("/bookings", booking);
    return response.data;
  },
};

export const propertyService = {
  getProperties: async (params: any = {}): Promise<any> => {
    const response = await api.get("/properties", { params });
    return response.data;
  },

  getPropertyById: async (id: string): Promise<any> => {
    const response = await api.get(`/properties/${id}`);
    return response.data;
  },

  createProperty: async (property: any): Promise<any> => {
    const response = await api.post("/properties", property);
    return response.data;
  },

  updateProperty: async (id: string, property: any): Promise<any> => {
    const response = await api.put(`/properties/${id}`, property);
    return response.data;
  },

  activateProperty: async (id: string): Promise<void> => {
    await api.post(`/properties/${id}/activate`);
  },

  deactivateProperty: async (id: string): Promise<void> => {
    await api.post(`/properties/${id}/deactivate`);
  },
};

export const roomService = {
  getRooms: async (params: any = {}): Promise<any> => {
    const response = await api.get("/rooms", { params });
    return response.data;
  },

  getRoomById: async (id: string): Promise<any> => {
    const response = await api.get(`/rooms/${id}`);
    return response.data;
  },

  updateRoomInfo: async (id: string, roomInfo: any): Promise<any> => {
    const response = await api.put(`/rooms/${id}/info`, roomInfo);
    return response.data;
  },

  setAvailability: async (id: string, availability: any): Promise<void> => {
    await api.post(`/rooms/${id}/availability`, availability);
  },

  setPriceOverride: async (id: string, priceOverride: any): Promise<void> => {
    await api.post(`/rooms/${id}/price-override`, priceOverride);
  },
};

export const reviewService = {
  getReviews: async (params: any = {}): Promise<any> => {
    const response = await api.get("/reviews", { params });
    return response.data;
  },

  getReviewById: async (id: string): Promise<any> => {
    const response = await api.get(`/reviews/${id}`);
    return response.data;
  },

  leaveReview: async (review: any): Promise<any> => {
    const response = await api.post("/reviews", review);
    return response.data;
  },

  updateComment: async (id: string, comment: any): Promise<any> => {
    const response = await api.put(`/reviews/${id}/comment`, comment);
    return response.data;
  },

  deleteReview: async (id: string): Promise<void> => {
    await api.delete(`/reviews/${id}`);
  },

  markAsInappropriate: async (id: string): Promise<void> => {
    await api.post(`/reviews/${id}/mark-inappropriate`);
  },
};

export const paymentService = {
  getPayments: async (params: any = {}): Promise<any> => {
    const response = await api.get("/payments", { params });
    return response.data;
  },

  getPaymentById: async (id: string): Promise<any> => {
    const response = await api.get(`/payments/${id}`);
    return response.data;
  },

  createPayment: async (payment: any): Promise<any> => {
    const response = await api.post("/payments", payment);
    return response.data;
  },

  markAsSuccessful: async (id: string, data: any): Promise<any> => {
    const response = await api.post(`/payments/${id}/mark-successful`, data);
    return response.data;
  },

  markAsFailed: async (id: string, data: any): Promise<any> => {
    const response = await api.post(`/payments/${id}/mark-failed`, data);
    return response.data;
  },

  refundPayment: async (id: string, data: any): Promise<any> => {
    const response = await api.post(`/payments/${id}/refund`, data);
    return response.data;
  },
};

export const imageService = {
  getImage: async (id: string): Promise<any> => {
    const response = await api.get(`/images/${id}`);
    return response.data;
  },

  createImage: async (image: any): Promise<any> => {
    const response = await api.post("/images", image);
    return response.data;
  },

  setAsPrimary: async (id: string): Promise<any> => {
    const response = await api.post(`/images/${id}/set-primary`);
    return response.data;
  },

  markForDeletion: async (id: string): Promise<void> => {
    await api.post(`/images/${id}/mark-for-deletion`);
  },
};

export const reservationService = {
  getReservationsByUser: async (userId: string): Promise<Reservation[]> => {
    const response = await api.get(`/reservations/user/${userId}`);
    return response.data;
  },

  createReservation: async (
    reservation: CreateReservationRequest
  ): Promise<Reservation> => {
    const response = await api.post("/reservations", reservation);
    return response.data;
  },

  getReservationById: async (id: string): Promise<Reservation> => {
    const response = await api.get(`/reservations/${id}`);
    return response.data;
  },
};

export { api };
export default api;
