# 📡 Core API Specifications (REV-BIL Module)

## 1. Overview
The Revenue & Billing (REV-BIL) module manages laboratory billing, invoice generation, payment processing, insurance coverage handling, and financial transaction logging. It communicates with patient, sample, and laboratory testing modules to calculate charges and maintain billing records.

---

## 2. Main Endpoints

### Endpoint 1: Create Invoice
* **Method:** `POST`
* **Route:** `/api/v1/billing/invoices`
* **Description:** Creates a new invoice for a patient's laboratory services.
* **Request Body (JSON):**
  * `patient_id` (String)
  * `sample_id` (String)
  * `test_ids` (Array of Strings)
* **Response Body (JSON - 201 Created):**
  * `invoice_id` (String)
  * `total_amount` (Decimal)
  * `status` (String: `Pending` / `Paid`)
  * `created_at` (DateTime)

### Endpoint 2: Get Invoice Details
* **Method:** `GET`
* **Route:** `/api/v1/billing/invoices/{invoice_id}`
* **Description:** Retrieves complete invoice metadata, patient information, and billed items.
* **Response Body (JSON - 200 OK):**
  * `invoice_id` (String)
  * `patient_id` (String)
  * `sample_id` (String)
  * `items` (Array of objects: `test_id`, `price`)
  * `total_amount` (Decimal)
  * `payment_status` (String)

### Endpoint 3: Record Payment
* **Method:** `POST`
* **Route:** `/api/v1/billing/payments`
* **Description:** Records a payment transaction against an active invoice. Supports routing to direct payment if insurance is rejected.
* **Request Body (JSON):**
  * `invoice_id` (String)
  * `amount` (Decimal)
  * `payment_method` (String: `Cash`, `Card`, `Insurance`)
* **Response Body (JSON - 200 OK):**
  * `payment_id` (String)
  * `payment_status` (String: `Settled`, `Rejected`)
  * `payment_date` (DateTime)

### Endpoint 4: Get Patient Billing History
* **Method:** `GET`
* **Route:** `/api/v1/billing/patients/{patient_id}/history`
* **Description:** Returns all historical invoices and payment logs for a specific patient.
* **Response Body (JSON - 200 OK):**
  * `patient_id` (String)
  * `invoices` (Array of Invoice Objects)
  * `payments` (Array of Payment Objects)
  * `outstanding_balance` (Decimal)

### Endpoint 5: Get Test Pricing (Dynamic Pricing)
* **Method:** `GET`
* **Route:** `/api/v1/billing/pricing`
* **Description:** Retrieves the customized price of a laboratory test based on the patient's categorization.
* **Query Parameters:**
  * `test_id` (String)
  * `patient_type` (String: `VIP`, `Standard`, `Insurance`)
* **Response Body (JSON - 200 OK):**
  * `test_id` (String)
  * `patient_type` (String)
  * `calculated_price` (Decimal)

### Endpoint 6: Log Financial Transaction (Audit Log)
* **Method:** `POST`
* **Route:** `/api/v1/billing/audit-logs`
* **Description:** Securely logs and locks financial transaction metadata to bind patient and sample data permanently.
* **Request Body (JSON):**
  * `invoice_id` (String)
  * `patient_id` (String)
  * `sample_id` (String)
  * `transaction_type` (String)
  * `amount` (Decimal)
* **Response Body (JSON - 201 Created):**
  * `log_id` (String)
  * `created_at` (DateTime)

### Endpoint 7: Verify Lab Result Release Clearance (Integration with LAB-TRK)
* **Method:** `GET`
* **Route:** `/api/v1/billing/clearance/{sample_id}`
* **Description:** **[Hard Stop Gatekeeper]** Called by `Module 6: LAB-TRK` to verify if payment or insurance coverage is secured before allowing technicians to input or approve results.
* **Response Body (JSON - 200 OK - Cleared):**
  * `sample_id` (String)
  * `is_cleared` (Boolean: `true`)
  * `payment_status` (String: `Paid` / `Covered`)
* **Response Body (JSON - 402 Payment Required - Blocked):**
  * `sample_id` (String)
  * `is_cleared` (Boolean: `false`)
  * `payment_status` (String: `Unpaid`)
  * `error_message` (String: "Access Locked: Results cannot be entered/released until financial settlement.")
