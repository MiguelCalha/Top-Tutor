# ✨Top Tutor ✨


## Introduction to TopTutor

Welcome to TopTutor, your ultimate destination for personalized tutoring services, where students can connect with expert tutors to achieve academic excellence. TopTutor is dedicated to providing a seamless platform that empowers both tutors and students alike, offering a wide array of functionalities to enhance the learning experience.

### Steps to run project
1. Clone the TopTutor repository from GitHub: [TopTutor Repository](https://github.com/MiguelCalha/Top-Tutor.git).
2. Open the solution file `TopTutor.sln` in Visual Studio.
3. Configure the database connection string in the `appsettings.json` file to point to your SQL Server instance.
4. Open the Package Manager Console in Visual Studio.
5. Delete the Migrations folder
6. Run the following commands in the Package Manager Console:
```sh
Add-Migration Initial
```

```sh
update-database
```
![Alt text](https://gcdnb.pbrd.co/images/pc0EYanWS8hq.png?o=1)


## Key Functionalities

### Authentication
- **Client Registration**: Register as a client to access our platform.
- **Client Login**: Securely log in to your account.
- **Admin Authentication**: Authenticate as an admin for administrative tasks.

### Tutor Management
- **Add Tutor Listing**: Admins can add new tutor listings with detailed information.
- **Delete Tutor Listing**: Admins have the authority to remove tutor listings.
- **Edit Tutor Listings**: Admins can modify existing tutor listings.
- **Add Photos to Tutor Listings**: Admins can upload photos to tutor listings.
- **View Tutor Listings**: Clients can browse and view tutor listings.

### Booking and Purchasing
- **Add Lessons to Cart**: Clients can add tutoring sessions to their shopping cart.
- **Purchase Tutoring Sessions**: Clients can buy tutoring sessions from a tutor.
- **View Shopping Cart**: Clients can view the contents of their shopping cart.
- **Remove Lessons from Cart**: Clients can remove tutoring sessions from their shopping cart.
- **Payment Confirmation Page (Admin)**: Admins can confirm purchases and send information to clients.
- **Add Payment Details**: Clients can add payment information.
- **Pay for Lessons at Checkout**: Clients can pay for tutoring sessions during checkout.
- **Approve Purchase of Lessons (Admin)**: Admins can approve the purchase of tutoring sessions.

### User Profile Management
- **View User Profile**: Users can view their profile information.
- **Change Password**: Users can change their passwords.
- **Change Email**: Users can update their email addresses.

### Administrative Tasks
- **Create Categories for Tutoring Areas (Admin)**: Admins can create categories for tutoring areas.
- **Edit Categories for Tutoring Areas (Admin)**: Admins can edit existing categories for tutoring areas.
- **Consult Purchase Information**: Users can access information regarding their purchases.

## Used Technologies
- N-Tier Architecure
- Entity Framework
- ASP .NET 8.0
- MSSQL
- Bootswatch
- Repository Patterm
- Unit Of Work Pattern
- Tiny MCE text editor

TopTutor is committed to revolutionizing the tutoring experience, providing a user-friendly platform where tutors and students can seamlessly connect and collaborate. Join us today and embark on your journey towards academic success with TopTutor!
