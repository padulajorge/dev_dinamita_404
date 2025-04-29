INSERT INTO codigo (lenguaje_id, nivel, segmento, codigo) VALUES
(1, 0, 1, ' '),
(1, 0, 2, 'public class Main {\n    public static void main(String[] args) {'),
(1, 0, 3, 'public class Main {\n    public static void main(String[] args) {\n        String nombre = "Ana";\n        System.out.println("Nombre: " + nombre);\n    }\n}'),
(1, 1, 1, ' '),
(1, 1, 2, 'public class Main {\n    public static void main(String[] args) {\n        private String nombre;\n    }\n}'),
(1, 1, 3, 'public class Main {\n    public static void main(String[] args) {\n        private String nombre;\n    }\n    public String getNombre() {\n        return nombre;\n    }\n}'),
(1, 1, 4, 'public class Main {\n    public static void main(String[] args) {\n        private String nombre;\n    }\n    public String getNombre() {\n        return nombre;\n    }\n    public void setNombre(String nombre) {\n        this.nombre = nombre;\n    }\n}'),
(1, 2, 1, ' '),
(1, 2, 2, 'public class Persona {\n    private String nombre;\n\n    public Persona(String nombre, int edad) {\n        this.nombre = nombre;\n    }\n}'),
(1, 2, 3, 'public class Persona {\n    private String nombre;\n\n    public Persona(String nombre, int edad) {\n        this.nombre = nombre;\n    }\n    public String getNombre() {\n        return nombre;\n    }\n}'),
(1, 2, 4, 'public class Persona {\n    private String nombre;\n\n    public Persona(String nombre, int edad) {\n        this.nombre = nombre;\n    }\n    public String getNombre() {\n        return nombre;\n    }\n    public void setNombre(String nombre) {\n        this.nombre = nombre;\n    }\n}'),
(1, 3, 1, ' '),
(1, 3, 2, 'public class Persona {\n    private String nombre;\n\n    public Persona(String nombre) {\n        this.nombre = nombre;\n    }\n}'),
(1, 3, 3, 'public class Persona {\n    private String nombre;\n\n    public Persona(String nombre) {\n        this.nombre = nombre;\n    }\n    public String getNombre() {\n        return nombre;\n    }\n    public void setNombre(String nombre) {\n        this.nombre = nombre;\n    }\n}'),
(1, 3, 4, 'public class Persona {\n    private String nombre;\n\n    public Persona(String nombre) {\n        this.nombre = nombre;\n    }\n    public String getNombre() {\n        return nombre;\n    }\n    public void setNombre(String nombre) {\n        this.nombre = nombre;\n    }\n}\n\npublic class Estudiante extends Persona {\n    private String carrera;\n\n    public Estudiante(String nombre, String carrera) {\n        super(nombre);\n        this.carrera = carrera;\n    }\n}'),
(1, 3, 5, 'public class Persona {\n    private String nombre;\n\n    public Persona(String nombre) {\n        this.nombre = nombre;\n    }\n    public String getNombre() {\n        return nombre;\n    }\n    public void setNombre(String nombre) {\n        this.nombre = nombre;\n    }\n}\n\npublic class Estudiante extends Persona {\n    private String carrera;\n\n    public Estudiante(String nombre, String carrera) {\n        super(nombre);\n        this.carrera = carrera;\n    }\n    public String getCarrera() {\n        return carrera;\n    }\n    public void setCarrera(String carrera) {\n        this.carrera = carrera;\n    }\n}'),
(1, 4, 1, ' '),
(1, 4, 2, 'public class Persona {\n    private String nombre;\n\n    public Persona(String nombre) {\n        this.nombre = nombre;\n    }\n}'),
(1, 4, 3, 'public class Persona {\n    private String nombre;\n\n    public Persona(String nombre) {\n        this.nombre = nombre;\n    }\n    public String getNombre() {\n        return nombre;\n    }\n    public void setNombre(String nombre) {\n        this.nombre = nombre;\n    }\n}'),
(1, 4, 4, 'public class Persona {\n    private String nombre;\n\n    public Persona(String nombre) {\n        this.nombre = nombre;\n    }\n    public String getNombre() {\n        return nombre;\n    }\n    public void setNombre(String nombre) {\n        this.nombre = nombre;\n    }\n}\n\npublic class Estudiante {\n    private String carrera;\n    private Persona persona; // Agregacion: Estudiante tiene una Persona\n\n    public Estudiante(String nombre, String carrera) {\n        this.persona = new Persona(nombre); // Crear una nueva Persona\n        this.carrera = carrera;\n    }\n}'),
(1, 4, 5, 'public class Persona {\n    private String nombre;\n\n    public Persona(String nombre) {\n        this.nombre = nombre;\n    }\n    public String getNombre() {\n        return nombre;\n    }\n    public void setNombre(String nombre) {\n        this.nombre = nombre;\n    }\n}\n\npublic class Estudiante {\n    private String carrera;\n    private Persona persona; // Agregacion: Estudiante tiene una Persona\n\n    public Estudiante(String nombre, String carrera) {\n        this.persona = new Persona(nombre); // Crear una nueva Persona\n        this.carrera = carrera;\n    }\n    public String getCarrera() {\n        return carrera;\n    }\n    public void setCarrera(String carrera) {\n        this.carrera = carrera;\n    }\n}'),
(1, 5, 1, ' '),
(1, 5, 2, 'public class Persona {\n    private String nombre;\n\n    public Persona(String nombre) {\n        this.nombre = nombre;\n    }\n}'),
(1, 5, 3, 'public class Persona {\n    private String nombre;\n\n    public Persona(String nombre) {\n        this.nombre = nombre;\n    }\n    public String getNombre() {\n        return nombre;\n    }\n    public void setNombre(String nombre) {\n        this.nombre = nombre;\n    }\n}'),
(1, 5, 4, 'public class Persona {\n    private String nombre;\n\n    public Persona(String nombre) {\n        this.nombre = nombre;\n    }\n    public String getNombre() {\n        return nombre;\n    }\n    public void setNombre(String nombre) {\n        this.nombre = nombre;\n    }\n}\n\npublic class Estudiante {\n    private String carrera;\n    private Persona persona; // Asociación: Estudiante conoce a Persona\n}'),
(1, 5, 5, 'public class Persona {\n    private String nombre;\n\n    public Persona(String nombre) {\n        this.nombre = nombre;\n    }\n    public String getNombre() {\n        return nombre;\n    }\n    public void setNombre(String nombre) {\n        this.nombre = nombre;\n    }\n}\n\npublic class Estudiante {\n    private String carrera;\n    private Persona persona; // Asociación: Estudiante conoce a Persona\n\n    public Estudiante(Persona persona, String carrera) {\n        this.persona = persona;\n        this.carrera = carrera;\n    }\n    public String getCarrera() {\n        return carrera;\n    }\n}'),
(1, 5, 6, 'public class Persona {\n    private String nombre;\n\n    public Persona(String nombre) {\n        this.nombre = nombre;\n    }\n    public String getNombre() {\n        return nombre;\n    }\n    public void setNombre(String nombre) {\n        this.nombre = nombre;\n    }\n}\n\npublic class Estudiante {\n    private String carrera;\n    private Persona persona; // Asociación: Estudiante conoce a Persona\n\n    public Estudiante(Persona persona, String carrera) {\n        this.persona = persona;\n        this.carrera = carrera;\n    }\n    public String getCarrera() {\n        return carrera;\n    }\n    public void setCarrera(String carrera) {\n        this.carrera = carrera;\n    }\n    public Persona getPersona() {\n        return persona;\n    }\n    public void setPersona(Persona persona) {\n        this.persona = persona;\n    }\n}');

INSERT INTO codigo (lenguaje_id, nivel, segmento, codigo) VALUES
-- 0 Base
(2, 0, 1, ' '),
(2, 0, 2, '#include <iostream>\n#include <string>\n\nint main() {\n'),
(2, 0, 3, '#include <iostream>\n#include <string>\n\nint main() {\n    std::string nombre = "Ana";\n'),
(2, 0, 4, '#include <iostream>\n#include <string>\n\nint main() {\n    std::string nombre = "Ana";\n    std::cout << "Nombre: " << nombre << std::endl;\n'),
(2, 0, 5, '#include <iostream>\n#include <string>\n\nint main() {\n    std::string nombre = "Ana";\n    std::cout << "Nombre: " << nombre << std::endl;\n    return 0;\n}'),

-- 1 Encapsulation
(2, 1, 1, ' '),
(2, 1, 2, '#include <string>\n\nclass Main {\nprivate:\n    std::string nombre;\n'),
(2, 1, 3, '#include <string>\n\nclass Main {\nprivate:\n    std::string nombre;\n\npublic:\n    std::string getNombre() {\n        return nombre;\n    }\n'),
(2, 1, 4, '#include <string>\n\nclass Main {\nprivate:\n    std::string nombre;\n\npublic:\n    std::string getNombre() {\n        return nombre;\n    }\n\n    void setNombre(const std::string& nombre) {\n        this->nombre = nombre;\n    }\n'),
(2, 1, 5, '#include <string>\n\nclass Main {\nprivate:\n    std::string nombre;\n\npublic:\n    std::string getNombre() {\n        return nombre;\n    }\n\n    void setNombre(const std::string& nombre) {\n        this->nombre = nombre;\n    }\n};'),

-- 2 Clase con encapsulamiento
(2, 2, 1, ' '),
(2, 2, 2, '#include <string>\n\nclass Persona {\nprivate:\n    std::string nombre;\n'),
(2, 2, 3, '#include <string>\n\nclass Persona {\nprivate:\n    std::string nombre;\n\npublic:\n    Persona(const std::string& nombre) {\n        this->nombre = nombre;\n    }\n'),
(2, 2, 4, '#include <string>\n\nclass Persona {\nprivate:\n    std::string nombre;\n\npublic:\n    Persona(const std::string& nombre) {\n        this->nombre = nombre;\n    }\n\n    std::string getNombre() const {\n        return nombre;\n    }\n'),
(2, 2, 5, '#include <string>\n\nclass Persona {\nprivate:\n    std::string nombre;\n\npublic:\n    Persona(const std::string& nombre) {\n        this->nombre = nombre;\n    }\n\n    std::string getNombre() const {\n        return nombre;\n    }\n\n    void setNombre(const std::string& nombre) {\n        this->nombre = nombre;\n    }\n};'),

-- 3 Herencia de clase
(2, 3, 1, ' '),
(2, 3, 2, '#include <string>\n\nclass Persona {\nprivate:\n    std::string nombre;\n'),
(2, 3, 3, '#include <string>\n\nclass Persona {\nprivate:\n    std::string nombre;\n\npublic:\n    Persona(const std::string& nombre) {\n        this->nombre = nombre;\n    }\n\n    std::string getNombre() const {\n        return nombre;\n    }\n\n    void setNombre(const std::string& nombre) {\n        this->nombre = nombre;\n    }\n};\n\nclass Estudiante : public Persona {\nprivate:\n    std::string carrera;\n'),
(2, 3, 4, '#include <string>\n\nclass Persona {\nprivate:\n    std::string nombre;\n\npublic:\n    Persona(const std::string& nombre) {\n        this->nombre = nombre;\n    }\n\n    std::string getNombre() const {\n        return nombre;\n    }\n\n    void setNombre(const std::string& nombre) {\n        this->nombre = nombre;\n    }\n};\n\nclass Estudiante : public Persona {\nprivate:\n    std::string carrera;\n\npublic:\n    Estudiante(const std::string& nombre, const std::string& carrera)\n        : Persona(nombre), carrera(carrera) {}\n'),
(2, 3, 5, '#include <string>\n\nclass Persona {\nprivate:\n    std::string nombre;\n\npublic:\n    Persona(const std::string& nombre) {\n        this->nombre = nombre;\n    }\n\n    std::string getNombre() const {\n        return nombre;\n    }\n\n    void setNombre(const std::string& nombre) {\n        this->nombre = nombre;\n    }\n};\n\nclass Estudiante : public Persona {\nprivate:\n    std::string carrera;\n\npublic:\n    Estudiante(const std::string& nombre, const std::string& carrera)\n        : Persona(nombre), carrera(carrera) {}\n\n    std::string getCarrera() const {\n        return carrera;\n    }\n\n    void setCarrera(const std::string& carrera) {\n        this->carrera = carrera;\n    }\n};'),

-- 4 Agregación
(2, 4, 1, ' '),
(2, 4, 2, '#include <string>\n\nclass Persona {\nprivate:\n    std::string nombre;\n'),
(2, 4, 3, '#include <string>\n\nclass Persona {\nprivate:\n    std::string nombre;\n\npublic:\n    Persona(const std::string& nombre) {\n        this->nombre = nombre;\n    }\n\n    std::string getNombre() const {\n        return nombre;\n    }\n\n    void setNombre(const std::string& nombre) {\n        this->nombre = nombre;\n    }\n};\n\nclass Estudiante {\nprivate:\n    std::string carrera;\n    Persona persona;\n'),
(2, 4, 4, '#include <string>\n\nclass Persona {\nprivate:\n    std::string nombre;\n\npublic:\n    Persona(const std::string& nombre) {\n        this->nombre = nombre;\n    }\n\n    std::string getNombre() const {\n        return nombre;\n    }\n\n    void setNombre(const std::string& nombre) {\n        this->nombre = nombre;\n    }\n};\n\nclass Estudiante {\nprivate:\n    std::string carrera;\n    Persona persona;\n\npublic:\n    Estudiante(const std::string& nombre, const std::string& carrera)\n        : persona(nombre), carrera(carrera) {}\n'),
(2, 4, 5, '#include <string>\n\nclass Persona {\nprivate:\n    std::string nombre;\n\npublic:\n    Persona(const std::string& nombre) {\n        this->nombre = nombre;\n    }\n\n    std::string getNombre() const {\n        return nombre;\n    }\n\n    void setNombre(const std::string& nombre) {\n        this->nombre = nombre;\n    }\n};\n\nclass Estudiante {\nprivate:\n    std::string carrera;\n    Persona persona;\n\npublic:\n    Estudiante(const std::string& nombre, const std::string& carrera)\n        : persona(nombre), carrera(carrera) {}\n\n    std::string getCarrera() const {\n        return carrera;\n    }\n\n    void setCarrera(const std::string& carrera) {\n        this->carrera = carrera;\n    }\n\n    Persona getPersona() const {\n        return persona;\n    }\n};'),

-- 5 Asociación
(2, 5, 1, ' '),
(2, 5, 2, '#include <string>\n\nclass Persona {\nprivate:\n    std::string nombre;\n'),
(2, 5, 3, '#include <string>\n\nclass Persona {\nprivate:\n    std::string nombre;\n\npublic:\n    Persona(const std::string& nombre) {\n        this->nombre = nombre;\n    }\n\n    std::string getNombre() const {\n        return nombre;\n    }\n\n    void setNombre(const std::string& nombre) {\n        this->nombre = nombre;\n    }\n};\n\nclass Estudiante {\nprivate:\n    std::string carrera;\n    Persona* persona;\n'),
(2, 5, 4, '#include <string>\n\nclass Persona {\nprivate:\n    std::string nombre;\n\npublic:\n    Persona(const std::string& nombre) {\n        this->nombre = nombre;\n    }\n\n    std::string getNombre() const {\n        return nombre;\n    }\n\n    void setNombre(const std::string& nombre) {\n        this->nombre = nombre;\n    }\n};\n\nclass Estudiante {\nprivate:\n    std::string carrera;\n    Persona* persona;\n\npublic:\n    Estudiante(Persona* persona, const std::string& carrera) {\n        this->persona = persona;\n        this->carrera = carrera;\n    }\n'),
(2, 5, 5, '#include <string>\n\nclass Persona {\nprivate:\n    std::string nombre;\n\npublic:\n    Persona(const std::string& nombre) {\n        this->nombre = nombre;\n    }\n\n    std::string getNombre() const {\n        return nombre;\n    }\n\n    void setNombre(const std::string& nombre) {\n        this->nombre = nombre;\n    }\n};\n\nclass Estudiante {\nprivate:\n    std::string carrera;\n    Persona* persona;\n\npublic:\n    Estudiante(Persona* persona, const std::string& carrera) {\n        this->persona = persona;\n        this->carrera = carrera;\n    }\n\n    std::string getCarrera() const {\n        return carrera;\n    }\n\n    void setCarrera(const std::string& carrera) {\n        this->carrera = carrera;\n    }\n\n    Persona* getPersona() const {\n        return persona;\n    }\n\n    void setPersona(Persona* persona) {\n        this->persona = persona;\n    }\n};');

INSERT INTO codigo (lenguaje_id, nivel, segmento, codigo) VALUES
(3, 0, 1, ' '),
(3, 0, 2, 'Module MainModule'),
(3, 0, 3, 'Module MainModule\n    Sub Main()\n        Dim nombre As String = "Ana"\n        Console.WriteLine("Nombre: " & nombre)\n    End Sub\nEnd Module'),

(3, 1, 1, ' '),
(3, 1, 2, 'Public Class Main'),
(3, 1, 3, 'Public Class Main\n    Private nombre As String'),
(3, 1, 4, 'Public Class Main\n    Private nombre As String\n\n    Public Property NombrePropiedad As String\n        Get\n            Return nombre\n        End Get'),
(3, 1, 5, 'Public Class Main\n    Private nombre As String\n\n    Public Property NombrePropiedad As String\n        Get\n            Return nombre\n        End Get\n        Set(value As String)\n            nombre = value\n        End Set\n    End Property\nEnd Class'),

(3, 2, 1, ' '),
(3, 2, 2, 'Public Class Persona'),
(3, 2, 3, 'Public Class Persona\n    Private nombre As String\n\n    Public Sub New(nombre As String)\n        Me.nombre = nombre\n    End Sub'),
(3, 2, 4, 'Public Class Persona\n    Private nombre As String\n\n    Public Sub New(nombre As String)\n        Me.nombre = nombre\n    End Sub\n\n    Public Property Nombre As String\n        Get\n            Return nombre\n        End Get'),
(3, 2, 5, 'Public Class Persona\n    Private nombre As String\n\n    Public Sub New(nombre As String)\n        Me.nombre = nombre\n    End Sub\n\n    Public Property Nombre As String\n        Get\n            Return nombre\n        End Get\n        Set(value As String)\n            nombre = value\n        End Set\n    End Property\nEnd Class'),

(3, 3, 1, ' '),
(3, 3, 2, 'Public Class Persona\n    Private nombre As String'),
(3, 3, 3, 'Public Class Persona\n    Private nombre As String\n\n    Public Sub New(nombre As String)\n        Me.nombre = nombre\n    End Sub\n\n    Public Property Nombre As String\n        Get\n            Return nombre\n        End Get\n        Set(value As String)\n            nombre = value\n        End Set\n    End Property\nEnd Class'),
(3, 3, 4, 'Public Class Estudiante\n    Inherits Persona\n\n    Private carrera As String\n\n    Public Sub New(nombre As String, carrera As String)\n        MyBase.New(nombre)\n        Me.carrera = carrera\n    End Sub'),
(3, 3, 5, 'Public Class Estudiante\n    Inherits Persona\n\n    Private carrera As String\n\n    Public Sub New(nombre As String, carrera As String)\n        MyBase.New(nombre)\n        Me.carrera = carrera\n    End Sub\n\n    Public Property Carrera As String\n        Get\n            Return carrera\n        End Get\n        Set(value As String)\n            carrera = value\n        End Set\n    End Property\nEnd Class'),

(3, 4, 1, ' '),
(3, 4, 2, 'Public Class Persona\n    Private nombre As String'),
(3, 4, 3, 'Public Class Persona\n    Private nombre As String\n\n    Public Sub New(nombre As String)\n        Me.nombre = nombre\n    End Sub\n\n    Public Property Nombre As String\n        Get\n            Return nombre\n        End Get\n        Set(value As String)\n            nombre = value\n        End Set\n    End Property\nEnd Class'),
(3, 4, 4, 'Public Class Estudiante\n    Private carrera As String\n    Private persona As Persona\n\n    Public Sub New(nombre As String, carrera As String)\n        persona = New Persona(nombre)\n        Me.carrera = carrera\n    End Sub'),
(3, 4, 5, 'Public Class Estudiante\n    Private carrera As String\n    Private persona As Persona\n\n    Public Sub New(nombre As String, carrera As String)\n        persona = New Persona(nombre)\n        Me.carrera = carrera\n    End Sub\n\n    Public Property Carrera As String\n        Get\n            Return carrera\n        End Get\n        Set(value As String)\n            carrera = value\n        End Set\n    End Property\n\n    Public Property DatosPersona As Persona\n        Get\n            Return persona\n        End Get\n        Set(value As Persona)\n            persona = value\n        End Set\n    End Property\nEnd Class'),

(3, 5, 1, ' '),
(3, 5, 2, 'Public Class Persona\n    Private nombre As String'),
(3, 5, 3, 'Public Class Persona\n    Private nombre As String\n\n    Public Sub New(nombre As String)\n        Me.nombre = nombre\n    End Sub\n\n    Public Property Nombre As String\n        Get\n            Return nombre\n        End Get\n        Set(value As String)\n            nombre = value\n        End Set\n    End Property\nEnd Class'),
(3, 5, 4, 'Public Class Estudiante\n    Private carrera As String\n    Private persona As Persona\n\n    Public Sub New(persona As Persona, carrera As String)\n        Me.persona = persona\n        Me.carrera = carrera\n    End Sub'),
(3, 5, 5, 'Public Class Estudiante\n    Private carrera As String\n    Private persona As Persona\n\n    Public Sub New(persona As Persona, carrera As String)\n        Me.persona = persona\n        Me.carrera = carrera\n    End Sub\n\n    Public Property Carrera As String\n        Get\n            Return carrera\n        End Get\n        Set(value As String)\n            carrera = value\n        End Set\n    End Property\n\n    Public Property DatosPersona As Persona\n        Get\n            Return persona\n        End Get\n        Set(value As Persona)\n            persona = value\n        End Set\n    End Property\nEnd Class');
