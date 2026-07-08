# ✅ Practice Checklist — Social Network API

> Simple, plain-language checklist for the whole practice. Check items off in order, top to bottom.
> Full explanations + code are in [01-domain-and-infrastructure.md](01-domain-and-infrastructure.md) and [02-api-auth-docker.md](02-api-auth-docker.md) — come back to this file just to track your progress.

---

## PART 1 — Domain & Infrastructure (do this first)

### Project setup
- [ ] Created 4 projects: `Domain`, `Application`, `Infrastructure`, `API`
- [ ] Projects reference each other in the right direction (API → Infrastructure/Application → Domain)

### Entities (the "things" in your app)
- [ ] `User` class created
- [ ] `Post` class created
- [ ] `Comment` class created
- [ ] `Like` class created
- [ ] `Follow` class created (this one connects two users — follower and following)

### Repositories (how you talk to the database)
- [ ] Generic repository interface created (`IRepository<T>`)
- [ ] A repository for each entity: Users, Posts, Comments, Likes, Follows
- [ ] `IUnitOfWork` created to save everything together

### DTOs (the data shapes sent in/out of the API)
- [ ] Register / Login request DTOs
- [ ] Auth response DTO (holds the token)
- [ ] User profile DTO
- [ ] Post request + response DTOs
- [ ] Comment request + response DTOs

### Services (the business logic)
- [ ] `UserService` — profile, follow, unfollow
- [ ] `PostService` — create, get, feed, delete
- [ ] `CommentService` — add, list
- [ ] `LikeService` — like, unlike
- [ ] Rule added: only the author can delete their own post
- [ ] Rule added: can't like the same post twice
- [ ] Rule added: can't follow yourself

### Database (EF Core)
- [ ] `AppDbContext` created with all 5 tables
- [ ] Username and Email are unique
- [ ] A user can only like a post once (unique rule in the database)
- [ ] A user can only follow another user once (unique rule in the database)
- [ ] Migration created (`dotnet ef migrations add InitialCreate`)
- [ ] Migration applied (`dotnet ef database update`) — tables show up in SQL Server

### Sanity check
- [ ] The app runs (`dotnet run`) with no errors, even before adding any API endpoints

**🎉 Only move to Part 2 once every box above is checked.**

---

## PART 2 — API, Login (JWT), Swagger, Logging & Docker

### API endpoints
- [ ] Auth: register + login
- [ ] Users: get profile, follow, unfollow, followers list, following list
- [ ] Posts: create, get one, get feed, delete
- [ ] Comments: add, list
- [ ] Likes: like, unlike
- [ ] Right status codes used (200/201/204/400/401/403/404/409)

### Login system (JWT) — new topic, go slow here
- [ ] I understand: a JWT is just a signed piece of text proving who I am
- [ ] I understand: the client sends it in the `Authorization: Bearer <token>` header on every request
- [ ] Passwords are hashed before saving (never saved as plain text)
- [ ] `TokenService` created — generates the token after login/register
- [ ] Token settings (`Jwt:Key`, `Issuer`, `Audience`) added to `appsettings.json`
- [ ] `Program.cs` set up to check tokens (`AddAuthentication` + `AddJwtBearer`)
- [ ] `app.UseAuthentication()` comes before `app.UseAuthorization()`
- [ ] All endpoints except register/login require login (`[Authorize]`)
- [ ] I can read "who is logged in" from the token inside a controller

### Swagger
- [ ] Swagger page opens in the browser
- [ ] Swagger has an "Authorize" button
- [ ] Pasting my token into that button lets me call protected endpoints from Swagger

### Logging & errors
- [ ] Serilog is set up (prints logs to console + a log file)
- [ ] One central place catches all errors (no random 500 crashes with stack traces shown to the user)
- [ ] Each type of error returns the right status code (not found = 404, forbidden = 403, conflict = 409, etc.)

### Docker
- [ ] `Dockerfile` created for the API
- [ ] `docker-compose.yml` created with two services: `api` and `sqlserver`
- [ ] `docker compose up --build` starts both containers without errors
- [ ] Database tables exist inside the container (migrations ran)
- [ ] Swagger works at `http://localhost:8080/swagger` while running through Docker

---

## 🏁 Final Proof It All Works

Do these in order, using Swagger (or Postman) against the Docker version:

- [ ] Register a new user → get a token back
- [ ] Log in with that user → get a token back
- [ ] Paste the token into Swagger's Authorize button
- [ ] Create a post
- [ ] Register a second user
- [ ] Second user follows the first user
- [ ] Second user checks their feed → sees the first user's post
- [ ] Like the same post twice → second time gives an error (409), not a crash
- [ ] Try deleting someone else's post → get blocked (403)
- [ ] Try calling a protected endpoint with no token → get blocked (401)
- [ ] Check the log file / `docker logs` → see the requests and errors logged

**When every box on this page is checked, the practice is done.**
