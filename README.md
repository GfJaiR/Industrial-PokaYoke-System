This project involved the development of a poka-yoke system designed to validate that production line processes are executed correctly. 
The system ensures that the correct raw materials are being used for each operation; otherwise, production is automatically blocked until all conditions are met.
The solution used a SeaLevel I/O device as an interface for communication with MPM Momentum and MPM Edison machine hardware, significantly reducing scrap rates and generating substantial cost savings for the company.

Additionally, the system was integrated with the plant’s MES (Manufacturing Execution System). 
A Cognex scanner was implemented to read QR codes from electronic boards, sending the scanned data to an API endpoint that provided the necessary information to determine whether a product was out of route. 
This added an extra layer of traceability and process control to the manufacturing workflow.

## Technologies Used
- C#
- WinForms/WPF
- Serial Communication
- Industrial Automation
- Manufacturing Validation
- Poka-Yoke
- SQL Server
- Hardware Communication (SeaLevel)
