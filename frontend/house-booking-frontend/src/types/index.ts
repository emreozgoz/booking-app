export interface House {
  id: string;
  title: string;
  description: string;
  address: string;
  pricePerNight: number;
  maxGuests: number;
  bedrooms: number;
  bathrooms: number;
  imageUrl: string;
  isAvailable: boolean;
  ownerId: string;
  createdAt: string;
  updatedAt: string;
}

export interface Booking {
  id: string;
  houseId: string;
  userId: string;
  checkInDate: string;
  checkOutDate: string;
  numberOfGuests: number;
  totalAmount: number;
  status: BookingStatus;
  specialRequests?: string;
  createdAt: string;
  updatedAt: string;
  house?: House;
}

export enum BookingStatus {
  Pending = 1,
  Confirmed = 2,
  Cancelled = 3,
  Completed = 4
}

export interface CreateBookingRequest {
  houseId: string;
  userId: string;
  checkInDate: string;
  checkOutDate: string;
  numberOfGuests: number;
  specialRequests?: string;
}

export interface CreateHouseRequest {
  title: string;
  description: string;
  address: string;
  pricePerNight: number;
  maxGuests: number;
  bedrooms: number;
  bathrooms: number;
  imageUrl: string;
  ownerId: string;
}

export interface HouseSearchParams {
  pageNumber?: number;
  pageSize?: number;
  searchTerm?: string;
  minPrice?: number;
  maxPrice?: number;
}

// New DDD Types
export interface Property {
  id: string;
  name: string;
  description: string;
  location: string;
  propertyType: string;
  ownerId: string;
  isActive: boolean;
  imageUrl: string;
  rating: number;
  reviewCount: number;
  availableRooms: number;
  pricePerNight: string;
  createdAt: string;
  updatedAt: string;
}

export interface Room {
  id: string;
  number: string;
  name: string;
  description: string;
  roomType: string;
  pricePerNight: string;
  maxOccupancy: number;
  size: number;
  isActive: boolean;
  propertyId: string;
  createdAt: string;
  updatedAt: string;
}

export interface Reservation {
  id: string;
  reservationNumber: string;
  propertyId: string;
  roomId: string;
  guestId: string;
  checkInDate: string;
  checkOutDate: string;
  numberOfGuests: number;
  totalAmount: string;
  status: ReservationStatus;
  specialRequests?: string;
  createdAt: string;
  updatedAt: string;
  property?: Property;
  room?: Room;
}

export enum ReservationStatus {
  Pending = 1,
  Confirmed = 2,
  Cancelled = 3,
  Completed = 4
}

export interface CreateReservationRequest {
  propertyId: string;
  guestId: string;
  checkInDate: string;
  checkOutDate: string;
  numberOfGuests: number;
  specialRequests?: string;
}

export interface PropertySearchParams {
  searchTerm?: string;
  location?: string;
  checkInDate?: string;
  checkOutDate?: string;
  numberOfGuests?: number;
  minPrice?: number;
  maxPrice?: number;
  propertyType?: string;
  pageNumber?: number;
  pageSize?: number;
}