# Module Name: Revenue & Billing System
## Project: MediChain Laboratory Management System
**Module Code:** REV-BIL

---

## 📝 Module Overview
The **Revenue & Billing (REV-BIL)** module is responsible for managing the financial and billing workflows of the laboratory. It automates dynamic pricing based on patient categories (e.g., VIP priority, Standard), strictly controls access to laboratory results by checking payment and insurance coverage status, and routes rejected transactions efficiently to direct payment. It serves as the financial gatekeeper to prevent any unauthorized release of medical data before financial clearance.
---

## 👥 Team Members & Responsibilities
*This table is flexible. Assign tasks based on team size (4 to 6 members).*

| Member Name | Primary Responsibility | Assigned Tasks (Examples) | GitHub Profile |
| :--- | :--- | :--- | :--- |
| **هدى السلوم المحمد (Leader)** | Requirement Elicitation | Collecting Functional Requirements (FRs) and Non-Functional Requirements (NFRs), Team Coordination | [[Link](https://github.com/huda05alsalloum-crypto)] |
| **نور الهدى شحود** | UML Behavioral Diagrams | Use Case Diagrams, Activity Diagrams | [[Link](https://github.com/NourAlHudaShahood)] |
| **مريم محمد** | UML Structural Diagrams | ERD, Class Diagrams | [[Link](https://github.com/Mariam-Mohammad)] |
| **اية المغربل** | Dynamic Modeling | Sequence Diagrams | [[Link](https://github.com/ayosh)] |
| **هيفاء عالية حموي** | Interface Design | Wireframes, Interface Design | [[Link](https://github.com/haifaahamwi)] |

---

## 🚀 Analysis & Design Progress
- [X] **Requirement Elicitation:** Completed list of FRs/NFRs.
- [ ] ### 📋 Detailed Functional Requirements (FRs)
* **FR-1 (Dynamic Pricing):** The system must apply different billing rates and prices depending on the `Patient Type` (VIP Priority, Standard Paid, etc.).
* **FR-2 (Access Control & Hard Stops):** The system must block entering or approving lab test results if `Payment Status` is unverified or missing insurance coverage.
* **FR-3 (Payment Rejection Routing):** In case of a rejected payment, the system must automatically route the workflow to "Direct Payment" or suspend the process until resolved.
* **FR-4 (Financial Auditing & Binding):** The system must securely log all financial transactions and bind them directly to both the `Sample ID` and `Patient ID`.
- [X] **UML Behavioral Diagrams:** Use Case and Activity Diagrams.
- [X] **UML Structural Diagrams:** ERD and Class Diagrams.
- [X] **Dynamic Modeling:** Sequence Diagrams for core processes.
- [x] **Interface Design:** Low-fidelity Wireframes.

---

## 🔗 Integration Points
*How this module communicates with others:*
How this module communicates with others:

* **Inbound:** Data received from `Module 6: LAB-TRK` (Patient Type, Required Lab Tests, and Sample ID).
* **Outbound:** Payment and Billing status sent back to `Module 6: LAB-TRK` (To approve or block releasing the test results based on payment).

---

## 🛠 Tools Used
## 🛠 Tools Used
* **Modeling:** StarUML / Lucidchart.
* **Documentation:** Markdown / Microsoft Word.
* **Version Control:** GitHub.
