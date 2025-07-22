# House Booking App

A comprehensive house booking application built with .NET 8 and React, featuring property management, room booking, and payment processing capabilities.

## 🤖 AI-Generated Project

**This entire project was generated using Claude AI.** No manual coding was performed - all code, architecture, database design, and configurations were created through AI assistance.

## Features

- **Property Management**: Create and manage rental properties with detailed information
- **Room Management**: Handle individual rooms within properties with pricing and availability
- **User Authentication**: JWT-based authentication with role-based access (Admin, Property Owner, Guest)
- **Booking System**: Complete reservation system with availability checking
- **Payment Processing**: Payment tracking and management system
- **Review System**: Guest reviews and ratings for properties
- **Image Management**: Property and room image handling
- **Real-time Availability**: Dynamic availability tracking for rooms

## Tech Stack

### Backend
- **.NET 8**: Web API framework
- **Entity Framework Core**: ORM with PostgreSQL database
- **MediatR**: CQRS pattern implementation
- **FluentValidation**: Input validation
- **JWT Authentication**: Secure token-based authentication
- **BCrypt**: Password hashing
- **Clean Architecture**: Domain-driven design principles

### Frontend
- **React**: User interface framework
- **TypeScript**: Type-safe JavaScript
- **Vite**: Fast build tool and dev server

### Database
- **PostgreSQL**: Primary database
- **Entity Framework Migrations**: Database schema management

## Project Structure

```
HouseBookingApp/
├── backend/
│   ├── HouseBookingApp.API/          # Web API controllers and configuration
│   ├── HouseBookingApp.Application/  # Business logic and CQRS handlers
│   ├── HouseBookingApp.Domain/       # Domain entities and business rules
│   ├── HouseBookingApp.Infrastructure/ # Data access and external services
│   └── HouseBookingApp.Shared/       # Shared utilities and models
└── frontend/
    └── house-booking-frontend/       # React application
```

## Getting Started

### Prerequisites

- .NET 8 SDK
- Node.js (v16 or higher)
- PostgreSQL
- Git

### Backend Setup

1. Clone the repository:
```bash
git clone <repository-url>
cd HouseBookingApp/backend
```

2. Update database connection string in `appsettings.json`:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=HouseBookingDb;Username=your_username;Password=your_password"
  }
}
```

3. Run database migrations:
```bash
dotnet ef database update --project HouseBookingApp.Infrastructure --startup-project HouseBookingApp.API
```

4. Start the API:
```bash
cd HouseBookingApp.API
dotnet run
```

The API will be available at `http://localhost:5124`

### Frontend Setup

1. Navigate to frontend directory:
```bash
cd frontend/house-booking-frontend
```

2. Install dependencies:
```bash
npm install
```

3. Start the development server:
```bash
npm run dev
```

The frontend will be available at `http://localhost:3000`

## API Endpoints

### Authentication
- `POST /api/auth/register` - User registration
- `POST /api/auth/login` - User login

### Properties
- `GET /api/properties` - Get all properties
- `GET /api/properties/{id}` - Get property by ID
- `POST /api/properties` - Create property (Property Owner/Admin)
- `PUT /api/properties/{id}` - Update property (Property Owner/Admin)
- `DELETE /api/properties/{id}` - Delete property (Admin)

### Rooms
- `GET /api/rooms` - Get all rooms
- `GET /api/rooms/{id}` - Get room by ID
- `POST /api/rooms` - Create room (Property Owner/Admin)
- `PUT /api/rooms/{id}` - Update room (Property Owner/Admin)

### Bookings
- `GET /api/bookings` - Get user bookings
- `POST /api/bookings` - Create booking
- `PUT /api/bookings/{id}` - Update booking

### Reviews
- `GET /api/reviews` - Get reviews
- `POST /api/reviews` - Create review
- `PUT /api/reviews/{id}` - Update review
- `DELETE /api/reviews/{id}` - Delete review

## Database Schema

The application uses a comprehensive database schema with the following main entities:

- **Users**: User accounts with role-based access
- **Properties**: Rental properties with location and details
- **Rooms**: Individual rooms within properties
- **Reservations**: Booking records
- **Payments**: Payment tracking
- **Reviews**: Property reviews and ratings
- **Images**: Property and room images
- **Amenities**: Available amenities for rooms

## Configuration

### JWT Settings
Configure JWT authentication in `appsettings.json`:
```json
{
  "Jwt": {
    "SecretKey": "your-secret-key-here",
    "Issuer": "HouseBookingApp",
    "Audience": "HouseBookingApp",
    "ExpirationMinutes": 60
  }
}
```

### CORS Settings
The API is configured to accept requests from:
- `http://localhost:3000` (React dev server)
- `http://localhost:5173` (Vite dev server)

## Development Notes

### Architecture Patterns
- **Clean Architecture**: Separation of concerns with Domain, Application, Infrastructure, and API layers
- **CQRS**: Command Query Responsibility Segregation using MediatR
- **Repository Pattern**: Data access abstraction
- **Unit of Work**: Transaction management

### Code Quality
- Input validation using FluentValidation
- Error handling with custom exceptions
- Logging integration
- Nullable reference types enabled

## Deployment

### Backend Deployment
1. Build the application:
```bash
dotnet publish -c Release
```

2. Configure production database connection
3. Run migrations in production
4. Deploy to your hosting platform

### Frontend Deployment
1. Build the React application:
```bash
npm run build
```

2. Deploy the `dist` folder to your web server

## Contributing

This project was entirely generated by Claude AI. Any modifications or enhancements should maintain the existing architecture and coding patterns established by the AI-generated codebase.

## License

This project is licensed under the MIT License.

## Acknowledgments

- **Claude AI**: For generating the entire codebase and architecture
- **Anthropic**: For providing the AI technology that created this project

---

*Generated entirely by Claude AI - No manual coding involved* 🤖 
