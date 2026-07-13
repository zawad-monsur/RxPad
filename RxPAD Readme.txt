PROJECT: RxPad — A SaaS Prescription Platform for Doctors
The Problem I'm Solving:
In Bangladesh, doctors write prescriptions by hand. The handwriting is often illegible, causing pharmacies to dispense wrong medicines or misread dosages — a genuine patient-safety issue. RxPad digitizes prescription creation so doctors produce clean, printed, machine-readable prescriptions. Think of it as a digital version of the doctor's prescription pad.
What the Product Does:
A doctor logs in and enters minimal patient info (name, age, sex, phone). They record clinical findings (BP, diabetes, weight, temperature, complaints, history, diagnosis), advise tests, and prescribe medicines (generic name, dosage, frequency like "1+0+1", duration, instructions like "after meal"). The doctor sets a follow-up date. The system generates a clean, professional prescription with the doctor's own letterhead (name, degrees, BMDC registration, chamber address and timing), plus a QR code. The doctor prints it and hands it to the patient, who takes the printed copy to a pharmacy to buy medicines. Every patient has a persistent log (found by phone / patient ID / DOB), so on the next visit the doctor sees the full history.
Key Product Requirements:

Minimal, fast data entry — doctors are busy and impatient; the UI must never slow them down.
A two-column prescription layout: left = findings / history / tests / instructions, right = medications (℞). Include free space for handwriting.
Auto-applied doctor letterhead on print.
Patient history accessible across visits.
Doctor-maintained favourite medicines and reusable prescription templates.

SaaS Model:
Doctors subscribe (Free 30-day trial → Basic → Pro). Features are gated by plan. Critically, the plan-to-feature mapping is stored in the database (a PlanFeatures table with Plan / FeatureName / IsEnabled), NOT hardcoded — so features can be toggled per plan without redeploying. Subscription state (Plan, Status, StartDate, EndDate) is checked on every request via middleware; a daily background job expires lapsed subscriptions.
Payment — deferred: There is NO payment gateway yet (no budget for SSLCommerz initially). Instead, the database must be designed so that subscription status and plan can be changed MANUALLY (via SQL or a small admin endpoint) for now, and a payment gateway (SSLCommerz, with webhook confirmation) can be plugged in LATER without any schema change. Subscription updates carry an "UpdatedBy" field ("Manual" now, "SSLCommerz" later). This is a deliberate application of Dependency Inversion — subscription logic is decoupled from the payment mechanism.
Tech Stack:

Backend: ASP.NET Core 8, C#, Clean Architecture (Domain / Application / Infrastructure / API)
Patterns: Repository + Unit of Work, CQRS with MediatR, Dependency Injection, SOLID, DB-driven Feature Flags, Middleware, Background Services (IHostedService)
Auth: JWT
Database: Microsoft SQL Server, Entity Framework Core
Frontend: React + TypeScript, Tailwind CSS, shadcn/ui — modern, trendy, clean, minimal, highly customizable and scalable, but simple enough that busy doctors stay engaged
PDF: QuestPDF; QR: QRCoder
DevOps: Docker, docker-compose, GitHub Actions CI/CD
Logging: Serilog

My Learning Goals (I'm building this to LEARN, not just to ship):
I'm a .NET developer comfortable with C#, ASP.NET Core, EF Core, Angular, and CQRS/MediatR in production. Through RxPad I want to master: Clean Architecture, Repository/Unit of Work, DB-driven feature flags, subscription middleware, background jobs, Docker + docker-compose from scratch, GitHub Actions CI/CD (push to main → auto build/test/deploy with Discord/Telegram/email notifications), unit testing (xUnit + Moq), and React (I know Angular; I need React for job requirements).
The Bigger Plan: I will FIRST build RxPad as a well-structured modular monolith to get a working, impressive, job-ready product. THEN I'll refactor it into microservices (Identity, Patient, Prescription, Notification services + YARP API Gateway + RabbitMQ + Redis + Saga / Outbox / Circuit-Breaker) — so I learn microservices by understanding WHY a monolith gets split, not by cargo-culting.
How I want to be taught:

One concept/feature at a time; explain WHY before HOW.
Meaningful code comments; name which pattern is applied and why.
Warn me about common mistakes before I make them.
After each major feature, give me one task to do alone.
Production-grade: real error handling, validation, logging.
I communicate in Banglish (Bangla + English mix); keep answers to the point.