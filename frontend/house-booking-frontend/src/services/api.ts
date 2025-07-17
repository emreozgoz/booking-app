import axios from "axios";
import type {
  House,
  Booking,
  CreateBookingRequest,
  CreateHouseRequest,
  HouseSearchParams,
  Property,
  Reservation,
  CreateReservationRequest,
  PropertySearchParams,
  Room,
} from "../types";

const API_BASE_URL = "https://localhost:7253/";

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
  getProperties: async (params: PropertySearchParams): Promise<Property[]> => {
    const response = await api.get("/properties", { params });
    return response.data;
  },

  getPropertyById: async (id: string): Promise<Property> => {
    const response = await api.get(`/properties/${id}`);
    return response.data;
  },

  getPropertyRooms: async (id: string): Promise<Room[]> => {
    const response = await api.get(`/properties/${id}/rooms`);
    return response.data;
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

export default api;
