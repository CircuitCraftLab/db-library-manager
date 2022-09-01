# DB Library Manager
This project was created to simplify the administration of a database component library for Altium Designer. This approach is the most convenient and least expensive for workstation resources.Initially, AD does not have a tool to populate the component library database. To date, there is already a library administration system - Concord Pro(ex. Vault), but it requires significant computer resources and is very slow. This approach requires a separate server to run and is completely unsuitable for a single developer or small team.

The basis of the DBMS for libraries is Microsoft Access. You can open an existing database or create a new one. When adding an existing database, a check will be made for the presence of required fields in each table.

The "Types of components" field displays a list of tables containing data about components. When you click the "Add New Component Type" button, a dialog box will appear prompting you to enter a table name. After pressing the "OK" button, the table will be added to the database with the specified name. You can also rename or delete an existing table.

The "Components" field contains a list of the components of the selected table. In it, you can also add a new component, as well as rename or delete an existing one.
