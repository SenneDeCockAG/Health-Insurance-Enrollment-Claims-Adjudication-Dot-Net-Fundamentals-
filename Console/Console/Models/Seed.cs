using eHealthApp.Models;

namespace Console.Models;

public static class Seed
{
    public static List<Member> Create()
    {
        var providers = new List<Provider>
        {
            new Provider
            {
                Npi = "1234567890",
                Name = "Dr. Alice Smith",
                Specialty = "Cardiology",
                City = "Springfield",
                State = "IL",
                InNetwork = true
            },
            new Provider
            {
                Npi = "9876543210",
                Name = "Dr. Bruno Martens",
                Specialty = "Radiology",
                City = "Bruxelles",
                State = "Brussels-Capital",
                InNetwork = true
            },
            new Provider
            {
                Npi = "1122334455",
                Name = "Dr. Sofia Garcia",
                Specialty = "Physiotherapy",
                City = "Madrid",
                State = "Madrid",
                InNetwork = false
            }
        };

        var plans = new List<Plan>
        {
            new Plan
            {
                PlanCode = "PLN-GOLD",
                PlanName = "Gold Health Plan",
                MonthlyPremium = 450.00m,
                Deductible = 500.00m,
                OutOfPocketMax = 3000.00m,
                HsaEligible = false
            },
            new Plan
            {
                PlanCode = "PLN-SILVER",
                PlanName = "Silver Health Plan",
                MonthlyPremium = 350.00m,
                Deductible = 1000.00m,
                OutOfPocketMax = 5000.00m,
                HsaEligible = true
            },
            new Plan
            {
                PlanCode = "PLN-PLATINUM",
                PlanName = "Platinum Health Plan",
                MonthlyPremium = 600.00m,
                Deductible = 250.00m,
                OutOfPocketMax = 2000.00m,
                HsaEligible = false
            }
        };

        var members = new List<Member>
        {
            new Member
            {
                FirstName = "Alice",
                LastName = "Johnson",
                DateOfBirth = new DateTime(1985, 4, 12),
                Email = "alice.johnson@example.com",
                Phone = "+1-202-555-0143",
                AddressLine1 = "123 Maple Street",
                AddressLine2 = "Apt 4B",
                City = "Springfield",
                State = "IL",
                PostalCode = "62704",
                Country = "USA",
                MembershipType = "Gold",
                EnrollmentStart = new DateTime(2023, 1, 1),
                EnrollmentEnd = new DateTime(2024, 1, 1),
                Enrollments = new List<Enrollment>
                {
                    new Enrollment
                    {
                        Plan = plans[0],
                        EnrollmentDate = new DateTime(2023, 1, 1),
                        TerminationDate = new DateTime(2024, 1, 1),
                        Status = "Terminated"
                    }
                },
                MedicalClaims = new List<MedicalClaim>
                {
                    new MedicalClaim
                    {
                        ClaimNumber = "CLM-20230901-001",
                        DateOfService = new DateTime(2023, 8, 15),
                        SubmittedAt = new DateTime(2023, 9, 1),
                        Status = "Processed",
                        TotalBilled = 250.00m,
                        TotalAllowed = 200.00m,
                        ClaimLines = new List<ClaimLine>
                        {
                            new ClaimLine
                            {
                                CptCode = "99213",
                                Icd10Code = "J01.90",
                                BilledAmount = 100.00m,
                                AllowedAmount = 80.00m,
                                CopayApplied = 20.00m,
                                CoinsuranceApplied = 0.00m,
                                DeductibleApplied = 0.00m,
                                PlanPaidAmount = 60.00m,
                                MemberResponsibility = 20.00m
                            },
                            new ClaimLine
                            {
                                CptCode = "71020",
                                Icd10Code = "R91.8",
                                BilledAmount = 150.00m,
                                AllowedAmount = 120.00m,
                                CopayApplied = 0.00m,
                                CoinsuranceApplied = 24.00m,
                                DeductibleApplied = 0.00m,
                                PlanPaidAmount = 96.00m,
                                MemberResponsibility = 24.00m
                            }
                        },
                        Provider = new Provider
                        {
                            Npi = "1234567890",
                            Name = "Dr. Alice Smith",
                            Specialty = "Cardiology",
                            City = "Springfield",
                            State = "IL",
                            InNetwork = true
                        }

                    }
                }
            },
            new Member
            {
                FirstName = "Bruno",
                LastName = "Martens",
                DateOfBirth = new DateTime(1990, 7, 23),
                Email = "bruno.martens@example.be",
                Phone = "+32-475-123456",
                AddressLine1 = "Rue de la Loi 200",
                City = "Bruxelles",
                State = "Brussels-Capital",
                PostalCode = "1000",
                Country = "Belgium",
                MembershipType = "Silver",
                EnrollmentStart = new DateTime(2024, 3, 15),
                EnrollmentEnd = new DateTime(2025, 3, 15),
                Enrollments = new List<Enrollment>
                {
                    new Enrollment
                    {
                        Plan = plans[1],
                        EnrollmentDate = new DateTime(2024, 3, 15),
                        Status = "Active"
                    }
                },
                MedicalClaims = new List<MedicalClaim>
                {
                    new MedicalClaim
                    {
                        ClaimNumber = "CLM-20230905-002",
                        DateOfService = new DateTime(2023, 9, 3),
                        SubmittedAt = new DateTime(2023, 9, 5),
                        Status = "Pending",
                        TotalBilled = 400.00m,
                        TotalAllowed = 350.00m,
                        ClaimLines = new List<ClaimLine>
                        {
                            new ClaimLine
                            {
                                CptCode = "80053",
                                Icd10Code = "E11.9",
                                BilledAmount = 200.00m,
                                AllowedAmount = 180.00m,
                                CopayApplied = 10.00m,
                                CoinsuranceApplied = 18.00m,
                                DeductibleApplied = 0.00m,
                                PlanPaidAmount = 152.00m,
                                MemberResponsibility = 28.00m
                            },
                            new ClaimLine
                            {
                                CptCode = "70551",
                                Icd10Code = "G43.909",
                                BilledAmount = 200.00m,
                                AllowedAmount = 170.00m,
                                CopayApplied = 20.00m,
                                CoinsuranceApplied = 30.00m,
                                DeductibleApplied = 0.00m,
                                PlanPaidAmount = 120.00m,
                                MemberResponsibility = 50.00m
                            }
                        },
                        Provider = new Provider
                        {
                            Npi = "9876543210",
                            Name = "Dr. Bruno Martens",
                            Specialty = "Radiology",
                            City = "Bruxelles",
                            State = "Brussels-Capital",
                            InNetwork = true
                        }
                    }
                }
            },
            new Member
            {
                FirstName = "Sofia",
                LastName = "Garcia",
                DateOfBirth = new DateTime(1995, 11, 5),
                Email = "sofia.garcia@example.es",
                Phone = "+34-612-345678",
                AddressLine1 = "Calle Mayor 45",
                AddressLine2 = "Piso 2",
                City = "Madrid",
                State = "Madrid",
                PostalCode = "28013",
                Country = "Spain",
                MembershipType = "Platinum",
                EnrollmentStart = new DateTime(2022, 6, 1),
                EnrollmentEnd = new DateTime(2025, 6, 1),
                Enrollments = new List<Enrollment>
                {
                    new Enrollment
                    {
                        Plan = plans[2],
                        EnrollmentDate = new DateTime(2022, 6, 1),
                        Status = "Active"
                    }
                },
                MedicalClaims = new List<MedicalClaim>
                {
                    new MedicalClaim
                    {
                        ClaimNumber = "CLM-20230910-003",
                        DateOfService = new DateTime(2023, 9, 8),
                        SubmittedAt = new DateTime(2023, 9, 10),
                        Status = "Rejected",
                        TotalBilled = 180.00m,
                        TotalAllowed = 0.00m,
                        ClaimLines = new List<ClaimLine>
                        {
                            new ClaimLine
                            {
                                CptCode = "97110",
                                Icd10Code = "M54.5",
                                BilledAmount = 180.00m,
                                AllowedAmount = 0.00m,
                                CopayApplied = 0.00m,
                                CoinsuranceApplied = 0.00m,
                                DeductibleApplied = 0.00m,
                                PlanPaidAmount = 0.00m,
                                MemberResponsibility = 180.00m
                            }
                        },
                        Provider = new Provider
                        {
                            Npi = "1122334455",
                            Name = "Dr. Sofia Garcia",
                            Specialty = "Physiotherapy",
                            City = "Madrid",
                            State = "Madrid",
                            InNetwork = false
                        }
                        
                    }
                }
            }
        };

        return members;
    }
}
