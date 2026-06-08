# Revenue & Billing Module Diagrams

## 1. Use Case Diagram
graph LR
    %% تعريف الممثلين خارج حدود النظام
    BillingClerk["👤 موظف الفوترة <br> (Billing Clerk)"]
    LabSystem["🖥️ نظام المختبر <br> (Lab System)"]

    %% حدود النظام (System Boundary)
    subgraph REV_BIL ["نظام الفوترة والتحصيل - REV-BIL System"]
        UC1("(احتساب السعر حسب نوع المريض)")
        UC2("(تسجيل العملية المالية وربطها بالعينة والمريض)")
        UC3("(التحقق من حالة الدفع والتغطية)")
        UC4("(معالجة رفض الدفع)")
        UC5("(حظر إدخال أو اعتماد نتائج التحاليل)")
        UC6("(تحويل الحالة إلى دفع مباشر)")
        UC7("(إيقاف العملية لحين المعالجة)")
    end

    %% ربط موظف الفوترة بحالات الاستخدام الخاصة به
    BillingClerk --- UC1
    BillingClerk --- UC2
    BillingClerk --- UC3
    BillingClerk --- UC4

    %% ربط نظام المختبر بحالة الحظر
    LabSystem --- UC5

    %% علاقات التوسيع (Extend) داخل النظام
    UC6 -.->|"<<extend>>"| UC4
    UC7 -.->|"<<extend>>"| UC4

    %% تحسينات بصرية للأشكال
    style BillingClerk fill:#e1f5fe,stroke:#0288d1,stroke-width:2px
    style LabSystem fill:#ffe0b2,stroke:#f57c00,stroke-width:2px
    style REV_BIL fill:#fafafa,stroke:#616161,stroke-width:2px

## 2. Activity Diagram
graph TD
    Start([● البداية]) --> Input[إدخال طلب التحليل وبيانات المريض]
    Input --> Calc[تحديد فئة المريض واحتساب السعر تلقائياً]
    Calc --> Decision1{هل تم الدفع أو التغطية؟}
    
    Decision1 -- نعم --> Record[تسجيل العملية المالية وربطها بالعينة والمريض]
    Decision1 -- لا / تم الرفض --> Decision2{معالجة الرفض}
    
    Decision2 -- تحويل لدفع مباشر --> Direct[تحويل الحالة إلى دفع مباشر وإتمام الدفع]
    Direct --> Record
    
    Decision2 -- إيقاف العملية --> Pause[إيقاف العملية مؤقتاً لحين المعالجة]
    Pause --> End1([◎ النهاية])
    
    Record --> LabAttempt[المختبر: محاولة إدخال أو اعتماد النتائج]
    LabAttempt --> Decision3{هل الفاتورة مدفوعة ومؤكدة؟}
    
    Decision3 -- نعم --> Allow[السماح بإدخال واعتماد النتائج في المختبر]
    Decision3 -- لا --> Block[حظر النظام للعملية وإصدار تنبيه مالي]
    
    Allow --> End2([◎ النهاية])
    Block --> End2
## 3. Sequence Diagram

sequenceDiagram
    actor Receptionist
    participant BillingSystem as Billing System
    participant InsuranceSystem as Insurance System
    participant PaymentService as Payment Service
    participant Database

    Receptionist->>BillingSystem: Create Invoice
    BillingSystem->>Database: Fetch Patient Data
    Database-->>BillingSystem: Patient Information

    BillingSystem->>InsuranceSystem: Verify Insurance Coverage
    InsuranceSystem-->>BillingSystem: Coverage Approved / Rejected

    alt Insurance Approved
        BillingSystem->>BillingSystem: Calculate Discount
    else No Insurance
        BillingSystem->>BillingSystem: Use Full Payment
    end

    Receptionist->>BillingSystem: Confirm Payment
    BillingSystem->>PaymentService: Process Payment
    PaymentService-->>BillingSystem: Payment Success / Failed

    alt Payment Successful
        BillingSystem->>Database: Save Payment Record
        BillingSystem->>Database: Update Invoice Status
        BillingSystem-->>Receptionist: Generate Receipt
        BillingSystem-->>Receptionist: Allow Result Approval
    else Payment Failed
        BillingSystem-->>Receptionist: Retry Payment
    end
