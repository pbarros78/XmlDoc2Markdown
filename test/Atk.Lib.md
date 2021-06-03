# Atk.Lib


## Common

Namespace: Atk.Lib

Clase con las funciones comunes

### Lista de métodos

| Método | Descripción |
| ---- | ---- |
| [GetConfiguration(String,String,Boolean)](#getconfiguration) | Obtiene un valor de la configuración (app.config o web.config) |
| [EvalVariableIsOn(String)](#evalvariableison) | Evalúa si la variable (de app.config) de tipo String está dentro de los valores [1, yes, si, true, on]. |
| [IsTrue(String)](#istrue) | Evalúa si la variable (de app.config) de tipo String está dentro de los valores [1, yes, si, true, on].  |
| [EvalVariableIsOff(String)](#evalvariableisoff) | Evalúa si la variable (de app.config) de tipo String está dentro de los valores [0, no, false, off]. |
| [IsFalse(String)](#isfalse) | Evalúa si la variable (de app.config) de tipo String está dentro de los valores [0, no, false, off]. |
| [GetEncode(String)](#getencode) | Evalúa el texto para buscar un encoding válido, por defecto entrega utf8 |
| [ConvertStringToBytes(String,String)](#convertstringtobytes) | Convierte un string a arreglo de bytes |
| [GetBytesFromString(String,String)](#getbytesfromstring) | Convierte un string a arreglo de bytes |
| [GetLengthFromString(String,String)](#getlengthfromstring) | Obtiene el largo del contenido de un String según su encoding |
| [DoTimeStamp(String)](#dotimestamp) | Devuelve el timeStamp de la fecha actual con formatos |
| [TimeStamp(String)](#timestamp) | Devuelve el timeStamp de la fecha actual con formatos |
| [IfNullOrEmpty(String,String)](#ifnullorempty) | Devuelve el valor de la variable y si es nula o vacía, devuelve el valor por defecto |


#### GetConfiguration

Obtiene un valor de la configuración (app.config o web.config)

```csharp
GetConfiguration(String key, String defaultValue, Boolean throwError)
```


###### Parámetros

| Parámetro | Tipo  | Descripción |
| ---- | ---- | ---- |
| **key** | [String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'String') | Clave o nombre a obtener |
| **defaultValue** | [String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'String') | Valor por defecto en caso de no existir o venir vacío |
| **throwError** | [Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'Boolean') | Arrojar error en caso de no existir la clave |


##### Retorna

Valor de la clave o valor por defecto

#### EvalVariableIsOn

Evalúa si la variable (de app.config) de tipo String está dentro de los valores [1, yes, si, true, on].

```csharp
EvalVariableIsOn(String variable)
```


###### Parámetros

| Parámetro | Tipo  | Descripción |
| ---- | ---- | ---- |
| **variable** | [String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'String') | Variable a evaluar. |


##### Retorna

Boolean

#### IsTrue

Evalúa si la variable (de app.config) de tipo String está dentro de los valores [1, yes, si, true, on]. 

Alias de: !:evalVariableIsOn(string)#R#

```csharp
IsTrue(String value)
```


###### Parámetros

| Parámetro | Tipo  | Descripción |
| ---- | ---- | ---- |
| **value** | [String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'String') | Variable a evaluar. |


##### Retorna

Boolean

#### EvalVariableIsOff

Evalúa si la variable (de app.config) de tipo String está dentro de los valores [0, no, false, off].

```csharp
EvalVariableIsOff(String variable)
```


###### Parámetros

| Parámetro | Tipo  | Descripción |
| ---- | ---- | ---- |
| **variable** | [String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'String') | Variable a evaluar. |


##### Retorna

Boolean

#### IsFalse

Evalúa si la variable (de app.config) de tipo String está dentro de los valores [0, no, false, off].

Alias de: !:evalVariableIsOff(string)#R#

```csharp
IsFalse(String value)
```


###### Parámetros

| Parámetro | Tipo  | Descripción |
| ---- | ---- | ---- |
| **value** | [String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'String') | Variable a evaluar. |


##### Retorna

Boolean

#### GetEncode

Evalúa el texto para buscar un encoding válido, por defecto entrega utf8

```csharp
GetEncode(String encoding)
```


###### Parámetros

| Parámetro | Tipo  | Descripción |
| ---- | ---- | ---- |
| **encoding** | [String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'String') | Texto con el encoding a evaluar |


##### Retorna

Encoding

#### ConvertStringToBytes

Convierte un string a arreglo de bytes

```csharp
ConvertStringToBytes(String text, String encoding)
```


###### Parámetros

| Parámetro | Tipo  | Descripción |
| ---- | ---- | ---- |
| **text** | [String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'String') | Texto a convertir |
| **encoding** | [String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'String') | Encoding a usar, acepta utf8, ascii y unicode |


#### GetBytesFromString
Convierte un string a arreglo de bytes

##### Lista de sobrecargas

| Sobrecarga | Descripción |
| ---- | ---- |
| [GetBytesFromString(String,String)](#getbytesfromstringstringstring) | Convierte un string a arreglo de bytes |
| [GetBytesFromString(String,Encoding)](#getbytesfromstringstringencoding) | Convierte un string a arreglo de bytes |



##### GetBytesFromString(String,String)
Convierte un string a arreglo de bytes
```csharp
GetBytesFromString(String text, String encoding)
```


###### Parámetros

| Parámetro | Tipo  | Descripción |
| ---- | ---- | ---- |
| **text** | [String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'String')  | Texto |
| **encoding** | [String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'String')  | Encoding, acepta utf8, ascii y unicode |


###### Retorna

Largo del texto

##### GetBytesFromString(String,Encoding)
Convierte un string a arreglo de bytes
```csharp
GetBytesFromString(String text, Encoding encode)
```


###### Parámetros

| Parámetro | Tipo  | Descripción |
| ---- | ---- | ---- |
| **text** | [String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'String') | Texto |
| **encode** | [Encoding](https://docs.microsoft.com/en-us/dotnet/api/System.Text.Encoding 'Encoding') | Encoding del texto |


###### Retorna

Largo del texto

#### GetLengthFromString
Obtiene el largo del contenido de un String según su encoding

##### Lista de sobrecargas

| Sobrecarga | Descripción |
| ---- | ---- |
| [GetLengthFromString(String,String)](#getlengthfromstringstringstring) | Obtiene el largo del contenido de un String según su encoding |
| [GetLengthFromString(String,Encoding)](#getlengthfromstringstringencoding) | Obtiene el largo del contenido de un String según su encoding |



##### GetLengthFromString(String,String)
Obtiene el largo del contenido de un String según su encoding
```csharp
GetLengthFromString(String text, String encoding)
```


###### Parámetros

| Parámetro | Tipo  | Descripción |
| ---- | ---- | ---- |
| **text** | [String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'String')  | Texto |
| **encoding** | [String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'String')  | Encoding, acepta utf8, ascii y unicode |


###### Retorna

Largo del texto

##### GetLengthFromString(String,Encoding)
Obtiene el largo del contenido de un String según su encoding
```csharp
GetLengthFromString(String text, Encoding encoding)
```


###### Parámetros

| Parámetro | Tipo  | Descripción |
| ---- | ---- | ---- |
| **text** | [String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'String') | Texto |
| **encoding** | [Encoding](https://docs.microsoft.com/en-us/dotnet/api/System.Text.Encoding 'Encoding') | Encoding del texto |


###### Retorna

Largo del texto

#### DoTimeStamp

Devuelve el timeStamp de la fecha actual con formatos

```csharp
DoTimeStamp(String Format)
```


###### Parámetros

| Parámetro | Tipo  | Descripción |
| ---- | ---- | ---- |
| **Format** | [String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'String') | Formatos permitidos: YM, YMD, YMDHMS, YMDHMSN, Y-M-DTH:M:S, Y-M-D H:M:S, MY, DMY, DMYHMS, DMYHMSN, D-M-YTH:M:S, D-M-Y H:M:S |


##### Retorna

String

#### TimeStamp

Devuelve el timeStamp de la fecha actual con formatos

Alias de: !:doTimeStamp(string)#R#

```csharp
TimeStamp(String Format)
```


###### Parámetros

| Parámetro | Tipo  | Descripción |
| ---- | ---- | ---- |
| **Format** | [String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'String') | Formatos permitidos: YM, YMD, YMDHMS, YMDHMSN, Y-M-DTH:M:S, Y-M-D H:M:S, MY, DMY, DMYHMS, DMYHMSN, D-M-YTH:M:S, D-M-Y H:M:S |


##### Retorna

String

#### IfNullOrEmpty

Devuelve el valor de la variable y si es nula o vacía, devuelve el valor por defecto

```csharp
IfNullOrEmpty(String Variable, String DefaultValue)
```


###### Parámetros

| Parámetro | Tipo  | Descripción |
| ---- | ---- | ---- |
| **Variable** | [String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'String') | Variable a consultar |
| **DefaultValue** | [String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'String') | Valor por defecto |


##### Retorna

String

## Dictionary

Namespace: Atk.Lib.Common

Clase para el manejo de keys del tipo Dictionary(string, string)

### Lista de constructores

| Constructor | Descripción |
| ---- | ---- |
| [Dictionary(Dictionary\<String,String>)](#dictionarydictionarystringstring) | Constructor en donde se define un diccionario por defecto |

#### Dictionary(Dictionary\<String,String>)


```csharp
var a = new Dictionary(Dictionary<String,String> dictionary)
```

Constructor en donde se define un diccionario por defecto


##### Parámetros del constructor

| Parámetro | Tipo  | Descripción |
| ---- | ---- | ---- |
| **dictionary** | [Dictionary](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'Dictionary')<[String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'String'),[String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'String')>  |  |


### Lista de métodos

| Método | Descripción |
| ---- | ---- |
| [Load(String)](#load) | Carga un diccionario desde un archivo JSON |
| [Add(String,String)](#add) | Agrega un nuevo set al diccionario |
| [GetValue(String)](#getvalue) | Obtiene el valor de una key |


#### Load
Carga un diccionario desde un archivo JSON

##### Lista de sobrecargas

| Sobrecarga | Descripción |
| ---- | ---- |
| [Load(String)](#loadstring) | Carga un diccionario desde un archivo JSON |
| [Load(Dictionary<String,String>)](#loaddictionarystringstring) | Carga un diccionario desde una estructura Dictionary(string, string) |



##### Load(String)
Carga un diccionario desde un archivo JSON
```csharp
Load(String fileName)
```


###### Parámetros

| Parámetro | Tipo  | Descripción |
| ---- | ---- | ---- |
| **fileName** | [String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'String')  |  |


##### Load(Dictionary<String,String>)
Carga un diccionario desde una estructura Dictionary(string, string)
```csharp
Load(Dictionary<String,String> dictionary)
```


###### Parámetros

| Parámetro | Tipo  | Descripción |
| ---- | ---- | ---- |
| **dictionary** | [Dictionary](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2 'Dictionary')<[String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'String'),[String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'String')> | Estructura del tipo Dictionary(string, string) |


#### Add

Agrega un nuevo set al diccionario

```csharp
Add(String key, String value)
```


###### Parámetros

| Parámetro | Tipo  | Descripción |
| ---- | ---- | ---- |
| **key** | [String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'String') | Clave |
| **value** | [String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'String') | Valor |


#### GetValue

Obtiene el valor de una key

```csharp
GetValue(String key)
```


###### Parámetros

| Parámetro | Tipo  | Descripción |
| ---- | ---- | ---- |
| **key** | [String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'String') | key |


## Md5

Namespace: Atk.Lib.Common

Clase con funciones para MD5

### Lista de métodos

| Método | Descripción |
| ---- | ---- |
| [Create(String,Encoding)](#create) | Genera el Hash MD5 de un texto con cierto encoding |


#### Create
Genera el Hash MD5 de un texto con cierto encoding

##### Lista de sobrecargas

| Sobrecarga | Descripción |
| ---- | ---- |
| [Create(String,Encoding)](#createstringencoding) | Genera el Hash MD5 de un texto con cierto encoding |
| [Create(String,String)](#createstringstring) | Genera el Hash MD5 de un texto con cierto encoding |



##### Create(String,Encoding)
Genera el Hash MD5 de un texto con cierto encoding
```csharp
Create(String input, Encoding encode)
```


###### Parámetros

| Parámetro | Tipo  | Descripción |
| ---- | ---- | ---- |
| **input** | [String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'String')  | Texto a encriptar. |
| **encode** | [Encoding](https://docs.microsoft.com/en-us/dotnet/api/System.Text.Encoding 'Encoding')  | Encoding a utilizar |


###### Retorna

String

##### Create(String,String)
Genera el Hash MD5 de un texto con cierto encoding
```csharp
Create(String input, String encode)
```


###### Parámetros

| Parámetro | Tipo  | Descripción |
| ---- | ---- | ---- |
| **input** | [String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'String') | Texto a encriptar. |
| **encode** | [String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'String') | Encoding a utilizar |


###### Retorna

String

## Base64

Namespace: Atk.Lib.Common

Clase con funciones para Base64

### Lista de métodos

| Método | Descripción |
| ---- | ---- |
| [isBase64String(String)](#isbase64string) | Verifica que el texto es un Base64 válido |
| [Encode(String)](#encode) | Codifica en Base64 un string |
| [DecodeString(String)](#decodestring) | Decodifica un string en Base64 |
| [DecodeByte(String)](#decodebyte) | Decodifica un string en Base64 |


#### isBase64String

Verifica que el texto es un Base64 válido

```csharp
isBase64String(String s)
```


###### Parámetros

| Parámetro | Tipo  | Descripción |
| ---- | ---- | ---- |
| **s** | [String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'String') | Texto a validar |


##### Retorna

True/False

#### Encode

Codifica en Base64 un string

```csharp
Encode(String str)
```


###### Parámetros

| Parámetro | Tipo  | Descripción |
| ---- | ---- | ---- |
| **str** | [String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'String') |  |


##### Retorna

String

#### DecodeString

Decodifica un string en Base64

```csharp
DecodeString(String str)
```


###### Parámetros

| Parámetro | Tipo  | Descripción |
| ---- | ---- | ---- |
| **str** | [String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'String') |  |


##### Retorna

String

#### DecodeByte

Decodifica un string en Base64

```csharp
DecodeByte(String str)
```


###### Parámetros

| Parámetro | Tipo  | Descripción |
| ---- | ---- | ---- |
| **str** | [String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'String') |  |


##### Retorna

Byte

## Data

Namespace: Atk.Lib.DataAccess

Clase para manejo de BD para proyectos WEB

### Lista de constructores

| Constructor | Descripción |
| ---- | ---- |
| [Data()](#data) | Llamada inicial de la clase |
| [Data(String,Int32)](#datastringint32) | Llamada inicial de la clase |
| [Data(String)](#datastring) | Llamada inicial de la clase |

#### Data()


```csharp
var a = new Data()
```

Llamada inicial de la clase

#### Data(String,Int32)


```csharp
var a = new Data(String connectionString, Int32 timeOut)
```

Llamada inicial de la clase


##### Parámetros del constructor

| Parámetro | Tipo  | Descripción |
| ---- | ---- | ---- |
| **connectionString** | [String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'String')  | Cadena de conexión a bases de datos (ODBC, SQL) |
| **timeOut** | [Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'Int32')  | Tiempo de espera para las consultas |

#### Data(String)


```csharp
var a = new Data(String connectionString)
```

Llamada inicial de la clase


##### Parámetros del constructor

| Parámetro | Tipo  | Descripción |
| ---- | ---- | ---- |
| **connectionString** | [String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'String')  | Cadena de conexión a bases de datos (ODBC, SQL) o Nombre (sin extensión) del archivo PrmXml |


### Lista de propiedades

| Propiedad | Descripción |
| ---- | ---- |
| **TimeOut** | Tiempo de espera para ejecutar las consultas |
| **ConnectionString** | Cadena de conexion a Base de Datos |
| **StoredProcedure** | Nombre del Procedimiento Almacenado |



### Lista de métodos

| Método | Descripción |
| ---- | ---- |
| [AddParameter(String,DbType,Object,Int32,ParameterDirection)](#addparameter) | Agrega un Parámetro al Procedimiento Almacenado a ejecutar |
| [Set(String)](#set) | Configura el nombre del Procedimiento Almacenado o Nombre (sin extensión) del archivo PrmXml |
| [Execute(String)](#execute) | Ejecuta el Procedimiento Almacenado configurado con el método Set, entregando un DataTable |
| [ExecuteDataSet(String,String)](#executedataset) | Ejecuta el Procedimiento Almacenado configurado con el método Set, entregando un DataSet |
| [Execute<T>()](#execute<t>) | Ejecuta el Procedimiento Almacenado configurado con el método Set, entregando un List del tipo (clase) pasado por parámetro |
| [ExecuteJSON<T>()](#executejson<t>) | Ejecuta el Procedimiento Almacenado configurado con el método Set, entregando un JSON (String) con la estructura del tipo (clase) pasado por parámetro |
| [ExecuteJSON(String,Boolean)](#executejson) | Ejecuta el Procedimiento Almacenado configurado con el método Set, entregando un JSON (String) con la estructura de la consulta recibida |
| [ExecuteJsonObject(String,Boolean)](#executejsonobject) | Ejecuta el Procedimiento Almacenado configurado con el método Set, entregando un Objeto JSON |
| [ExecuteJsonArray(String,Boolean)](#executejsonarray) | Ejecuta el Procedimiento Almacenado configurado con el método Set, entregando un arreglo JSON |
| [ExecuteXML<T>()](#executexml<t>) | Ejecuta el Procedimiento Almacenado configurado con el método Set, entregando un XML (String) con la estructura del tipo (clase) pasado por parámetro |
| [ExecuteXML(String,String)](#executexml) | Ejecuta el Procedimiento Almacenado configurado con el método Set, entregando un XML (String) con la estructura de la consulta recibida |


#### AddParameter
Agrega un Parámetro al Procedimiento Almacenado a ejecutar

##### Lista de sobrecargas

| Sobrecarga | Descripción |
| ---- | ---- |
| [AddParameter(String,DbType,Object,Int32,ParameterDirection)](#addparameterstringdbtypeobjectint32parameterdirection) | Agrega un Parámetro al Procedimiento Almacenado a ejecutar |
| [AddParameter(String,Object)](#addparameterstringobject) | Modifica el valor de un parámetro existente |



##### AddParameter(String,DbType,Object,Int32,ParameterDirection)
Agrega un Parámetro al Procedimiento Almacenado a ejecutar
```csharp
AddParameter(String name, DbType type, Object value, Int32 length, ParameterDirection direction)
```


###### Parámetros

| Parámetro | Tipo  | Descripción |
| ---- | ---- | ---- |
| **name** | [String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'String')  | Nombre del Parámetro |
| **type** | [DbType](https://docs.microsoft.com/en-us/dotnet/api/System.Data.DbType 'DbType')  | Tipo del Parámetro |
| **value** | [Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'Object')  | Valor del Parámetro |
| **length** | [Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'Int32')  | Largo del Parámetro |
| **direction** | [ParameterDirection](https://docs.microsoft.com/en-us/dotnet/api/System.Data.ParameterDirection 'ParameterDirection')  | Dirección del Parámetro |


###### Retorna

Objeto DataAccess para encadenamiento de sintaxis

##### AddParameter(String,Object)
Modifica el valor de un parámetro existente
```csharp
AddParameter(String name, Object value)
```


###### Parámetros

| Parámetro | Tipo  | Descripción |
| ---- | ---- | ---- |
| **name** | [String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'String') | Nombre del Parámetro |
| **value** | [Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'Object') | Valor del Parámetro |


###### Retorna

Objeto DataAccess para encadenamiento de sintaxis

#### Set

Configura el nombre del Procedimiento Almacenado o Nombre (sin extensión) del archivo PrmXml

```csharp
Set(String StoredProcedure)
```


###### Parámetros

| Parámetro | Tipo  | Descripción |
| ---- | ---- | ---- |
| **StoredProcedure** | [String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'String') | Nombre del Procedimiento Almacenado o Nombre (sin extensión) del archivo PrmXml |


##### Retorna

Objeto DataAccess para encadenamiento de sintaxis

#### Execute

Ejecuta el Procedimiento Almacenado configurado con el método Set, entregando un DataTable

```csharp
Execute(String nameCollection)
```


###### Parámetros

| Parámetro | Tipo  | Descripción |
| ---- | ---- | ---- |
| **nameCollection** | [String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'String') | Nombre de la DataTable, por defecto ROW |


#### ExecuteDataSet

Ejecuta el Procedimiento Almacenado configurado con el método Set, entregando un DataSet

```csharp
ExecuteDataSet(String nameRoot, String nameCollection)
```


###### Parámetros

| Parámetro | Tipo  | Descripción |
| ---- | ---- | ---- |
| **nameRoot** | [String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'String') | Nombre del DataSet, por defecto ROWS |
| **nameCollection** | [String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'String') | Nombre de la DataTable, por defecto ROW |


#### Execute<T>

Ejecuta el Procedimiento Almacenado configurado con el método Set, entregando un List del tipo (clase) pasado por parámetro

```csharp
Execute<T>()
```


###### Parámetros

| Parámetro | Tipo  | Descripción |
| ---- | ---- | ---- |


##### Retorna

List del tipo (clase)

#### ExecuteJSON<T>

Ejecuta el Procedimiento Almacenado configurado con el método Set, entregando un JSON (String) con la estructura del tipo (clase) pasado por parámetro

```csharp
ExecuteJSON<T>()
```


###### Parámetros

| Parámetro | Tipo  | Descripción |
| ---- | ---- | ---- |


##### Retorna

JSON (String) con la estructura del tipo (clase)

#### ExecuteJSON

Ejecuta el Procedimiento Almacenado configurado con el método Set, entregando un JSON (String) con la estructura de la consulta recibida

```csharp
ExecuteJSON(String nameCollection, Boolean upperCaseNames)
```


###### Parámetros

| Parámetro | Tipo  | Descripción |
| ---- | ---- | ---- |
| **nameCollection** | [String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'String') | Nombre del Array de resultados principal, por defecto ROWS |
| **upperCaseNames** | [Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'Boolean') | Nombres de campos en mayúscula = TRUE, como viene en la consulta = FALSE |


##### Retorna

JSON (String)

#### ExecuteJsonObject

Ejecuta el Procedimiento Almacenado configurado con el método Set, entregando un Objeto JSON

```csharp
ExecuteJsonObject(String nameCollection, Boolean upperCaseNames)
```


###### Parámetros

| Parámetro | Tipo  | Descripción |
| ---- | ---- | ---- |
| **nameCollection** | [String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'String') | Nombre del Array de resultados principal, por defecto ROWS |
| **upperCaseNames** | [Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'Boolean') | Nombres de campos en mayúscula = TRUE, como viene en la consulta = FALSE |


##### Retorna

JSON (Objeto)

#### ExecuteJsonArray

Ejecuta el Procedimiento Almacenado configurado con el método Set, entregando un arreglo JSON

```csharp
ExecuteJsonArray(String nameCollection, Boolean upperCaseNames)
```


###### Parámetros

| Parámetro | Tipo  | Descripción |
| ---- | ---- | ---- |
| **nameCollection** | [String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'String') | Nombre del Array de resultados principal, por defecto ROWS |
| **upperCaseNames** | [Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'Boolean') | Nombres de campos en mayúscula = TRUE, como viene en la consulta = FALSE |


##### Retorna

JSON (Objeto)

#### ExecuteXML<T>

Ejecuta el Procedimiento Almacenado configurado con el método Set, entregando un XML (String) con la estructura del tipo (clase) pasado por parámetro

```csharp
ExecuteXML<T>()
```


###### Parámetros

| Parámetro | Tipo  | Descripción |
| ---- | ---- | ---- |


##### Retorna

XML (String) con la estructura del tipo (clase)

#### ExecuteXML

Ejecuta el Procedimiento Almacenado configurado con el método Set, entregando un XML (String) con la estructura de la consulta recibida

```csharp
ExecuteXML(String nameRoot, String nameCollection)
```


###### Parámetros

| Parámetro | Tipo  | Descripción |
| ---- | ---- | ---- |
| **nameRoot** | [String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'String') | Nombre del Nodo principal, por defecto ROWS |
| **nameCollection** | [String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'String') | Nombre de los Nodos secundarios (lista), por defecto ROW |


##### Retorna

XML (String)

## IniFile

Namespace: Atk.Lib.FileSystem

Clase para manejo de archivos INI

### Lista de constructores

| Constructor | Descripción |
| ---- | ---- |
| [IniFile()](#inifile) | Constructor de la clase |
| [IniFile(String)](#inifilestring) | Constructor de la clase |

#### IniFile()


```csharp
var a = new IniFile()
```

Constructor de la clase

#### IniFile(String)


```csharp
var a = new IniFile(String FileName)
```

Constructor de la clase


##### Parámetros del constructor

| Parámetro | Tipo  | Descripción |
| ---- | ---- | ---- |
| **FileName** | [String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'String')  | Archivo INI a consultar |


### Lista de métodos

| Método | Descripción |
| ---- | ---- |
| [Parse()](#parse) | Lee el archivo y lo vuelca a una estructura de tipo diccionario. De haber elementos repetidos sólo se toma el primero. |
| [SetSection(String)](#setsection) | Asigna una sección del archivo INI para consultarlo directo con GET |
| [Get(String,String)](#get) | Obtiene el valor de una clave en el archivo INI, si no lo encuentra devuelve null |


#### Parse
Lee el archivo y lo vuelca a una estructura de tipo diccionario. De haber elementos repetidos sólo se toma el primero.

##### Lista de sobrecargas

| Sobrecarga | Descripción |
| ---- | ---- |
| [Parse()](#parse) | Lee el archivo y lo vuelca a una estructura de tipo diccionario. De haber elementos repetidos sólo se toma el primero. |
| [Parse(String)](#parsestring) | Lee el archivo y lo vuelca a una estructura de tipo diccionario. De haber elementos repetidos sólo se toma el primero. |



##### Parse()
Lee el archivo y lo vuelca a una estructura de tipo diccionario. De haber elementos repetidos sólo se toma el primero.
```csharp
Parse()
```


###### Parámetros

| Parámetro | Tipo  | Descripción |
| ---- | ---- | ---- |


##### Parse(String)
Lee el archivo y lo vuelca a una estructura de tipo diccionario. De haber elementos repetidos sólo se toma el primero.
```csharp
Parse(String FileName)
```


###### Parámetros

| Parámetro | Tipo  | Descripción |
| ---- | ---- | ---- |
| **FileName** | [String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'String') | Archivo INI a consultar |


#### SetSection

Asigna una sección del archivo INI para consultarlo directo con GET

```csharp
SetSection(String Section)
```


###### Parámetros

| Parámetro | Tipo  | Descripción |
| ---- | ---- | ---- |
| **Section** | [String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'String') | Sección del archivo INI a consultar |


#### Get
Obtiene el valor de una clave en el archivo INI, si no lo encuentra devuelve null

##### Lista de sobrecargas

| Sobrecarga | Descripción |
| ---- | ---- |
| [Get(String,String)](#getstringstring) | Obtiene el valor de una clave en el archivo INI, si no lo encuentra devuelve null |
| [Get(String)](#getstring) | Obtiene el valor de una clave en el archivo INI, si no lo encuentra devuelve null |



##### Get(String,String)
Obtiene el valor de una clave en el archivo INI, si no lo encuentra devuelve null
```csharp
Get(String Section, String Name)
```


###### Parámetros

| Parámetro | Tipo  | Descripción |
| ---- | ---- | ---- |
| **Section** | [String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'String')  | Sección del archivo INI a consultar |
| **Name** | [String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'String')  | Nombre de la clave |


###### Retorna

Valor de la clave

##### Get(String)
Obtiene el valor de una clave en el archivo INI, si no lo encuentra devuelve null
```csharp
Get(String Name)
```


###### Parámetros

| Parámetro | Tipo  | Descripción |
| ---- | ---- | ---- |
| **Name** | [String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'String') | Nombre de la clave |


###### Retorna

Valor de la clave

## Portal

Namespace: Atk.Lib

Clase para el manejo de variables, request y otros en portales Artikos

### Lista de métodos

| Método | Descripción |
| ---- | ---- |
| [GetClientIP(HttpContext)](#getclientip) | Obtiene la IP del Cliente dentro de la red Artikos |


#### GetClientIP

Obtiene la IP del Cliente dentro de la red Artikos

```csharp
GetClientIP(HttpContext context)
```


###### Parámetros

| Parámetro | Tipo  | Descripción |
| ---- | ---- | ---- |
| **context** | [HttpContext](https://docs.microsoft.com/en-us/dotnet/api/System.Web.HttpContext 'HttpContext') | Request del contexto |


##### Retorna

String

## Request

Namespace: Atk.Lib.Portal

Clase para el manejo de los Request (GET, POST, opciones string tipo QueryString)

### Lista de métodos

| Método | Descripción |
| ---- | ---- |
| [GetPost(HttpRequest,String,String)](#getpost) | Obtiene el request con el metodo POST y si viene vacío o no viene, se puede asignar un valor por defecto |
| [GetGet(HttpRequest,String,String)](#getget) | Obtiene el request con el metodo GET y si viene vacío o no viene, se puede asignar un valor por defecto |
| [GetRequest(HttpRequest,String,String,String)](#getrequest) | Obtiene el request (POST o GET) y si viene vacío o no viene, se puede asignar un valor por defecto |
| [GetOptions(String,String)](#getoptions) | Obtiene la opción de una cadena QueryString |


#### GetPost
Obtiene el request con el metodo POST y si viene vacío o no viene, se puede asignar un valor por defecto

##### Lista de sobrecargas

| Sobrecarga | Descripción |
| ---- | ---- |
| [GetPost(HttpRequest,String,String)](#getposthttprequeststringstring) | Obtiene el request con el metodo POST y si viene vacío o no viene, se puede asignar un valor por defecto |
| [GetPost(HttpRequest,String)](#getposthttprequeststring) | Obtiene el request con el metodo POST, y si no viene devuelve null |



##### GetPost(HttpRequest,String,String)
Obtiene el request con el metodo POST y si viene vacío o no viene, se puede asignar un valor por defecto
```csharp
GetPost(HttpRequest request, String name, String defaultValue)
```


###### Parámetros

| Parámetro | Tipo  | Descripción |
| ---- | ---- | ---- |
| **request** | [HttpRequest](https://docs.microsoft.com/en-us/dotnet/api/System.Web.HttpRequest 'HttpRequest')  | Request del contexto |
| **name** | [String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'String')  | Nombre de la variable |
| **defaultValue** | [String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'String')  | Valor por defecto |


###### Retorna

String

##### GetPost(HttpRequest,String)
Obtiene el request con el metodo POST, y si no viene devuelve null
```csharp
GetPost(HttpRequest request, String name)
```


###### Parámetros

| Parámetro | Tipo  | Descripción |
| ---- | ---- | ---- |
| **request** | [HttpRequest](https://docs.microsoft.com/en-us/dotnet/api/System.Web.HttpRequest 'HttpRequest') | Request del contexto |
| **name** | [String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'String') | Nombre de la variable |


###### Retorna

String

#### GetGet
Obtiene el request con el metodo GET y si viene vacío o no viene, se puede asignar un valor por defecto

##### Lista de sobrecargas

| Sobrecarga | Descripción |
| ---- | ---- |
| [GetGet(HttpRequest,String,String)](#getgethttprequeststringstring) | Obtiene el request con el metodo GET y si viene vacío o no viene, se puede asignar un valor por defecto |
| [GetGet(HttpRequest,String)](#getgethttprequeststring) | Obtiene el request con el metodo GET, y si no viene devuelve null |



##### GetGet(HttpRequest,String,String)
Obtiene el request con el metodo GET y si viene vacío o no viene, se puede asignar un valor por defecto
```csharp
GetGet(HttpRequest request, String name, String defaultValue)
```


###### Parámetros

| Parámetro | Tipo  | Descripción |
| ---- | ---- | ---- |
| **request** | [HttpRequest](https://docs.microsoft.com/en-us/dotnet/api/System.Web.HttpRequest 'HttpRequest')  | Request del contexto |
| **name** | [String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'String')  | Nombre de la variable |
| **defaultValue** | [String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'String')  | Valor por defecto |


###### Retorna

String

##### GetGet(HttpRequest,String)
Obtiene el request con el metodo GET, y si no viene devuelve null
```csharp
GetGet(HttpRequest request, String name)
```


###### Parámetros

| Parámetro | Tipo  | Descripción |
| ---- | ---- | ---- |
| **request** | [HttpRequest](https://docs.microsoft.com/en-us/dotnet/api/System.Web.HttpRequest 'HttpRequest') | Request del contexto |
| **name** | [String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'String') | Nombre de la variable |


###### Retorna

String

#### GetRequest
Obtiene el request (POST o GET) y si viene vacío o no viene, se puede asignar un valor por defecto

##### Lista de sobrecargas

| Sobrecarga | Descripción |
| ---- | ---- |
| [GetRequest(HttpRequest,String,String,String)](#getrequesthttprequeststringstringstring) | Obtiene el request (POST o GET) y si viene vacío o no viene, se puede asignar un valor por defecto |
| [GetRequest(HttpRequest,String,String)](#getrequesthttprequeststringstring) | Obtiene el request (POST o GET) y si viene vacío o no viene, se puede asignar un valor por defecto |



##### GetRequest(HttpRequest,String,String,String)
Obtiene el request (POST o GET) y si viene vacío o no viene, se puede asignar un valor por defecto
```csharp
GetRequest(HttpRequest Request, String Method, String Name, String DefaultValue)
```


###### Parámetros

| Parámetro | Tipo  | Descripción |
| ---- | ---- | ---- |
| **Request** | [HttpRequest](https://docs.microsoft.com/en-us/dotnet/api/System.Web.HttpRequest 'HttpRequest')  | Request del contexto |
| **Method** | [String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'String')  | Método para la obtención del Request |
| **Name** | [String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'String')  | Nombre de la variable |
| **DefaultValue** | [String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'String')  | Valor por defecto - Opcional |


###### Retorna

String

##### GetRequest(HttpRequest,String,String)
Obtiene el request (POST o GET) y si viene vacío o no viene, se puede asignar un valor por defecto
```csharp
GetRequest(HttpRequest Request, String Method, String Name)
```


###### Parámetros

| Parámetro | Tipo  | Descripción |
| ---- | ---- | ---- |
| **Request** | [HttpRequest](https://docs.microsoft.com/en-us/dotnet/api/System.Web.HttpRequest 'HttpRequest') | Request del contexto |
| **Method** | [String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'String') | Método para la obtención del Request |
| **Name** | [String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'String') | Nombre de la variable |


###### Retorna

String

#### GetOptions

Obtiene la opción de una cadena QueryString

```csharp
GetOptions(String var, String name)
```


###### Parámetros

| Parámetro | Tipo  | Descripción |
| ---- | ---- | ---- |
| **var** | [String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'String') | Variable que contiene el QueryString |
| **name** | [String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'String') | Nombre de la variable a buscar |


##### Retorna

String

## Session

Namespace: Atk.Lib.Portal

Clase que sirve para interactuar con las sesiones web de ASP Clásico

### Lista de constructores

| Constructor | Descripción |
| ---- | ---- |
| [Session(HttpContext)](#sessionhttpcontext) | Setea el objeto Context |

#### Session(HttpContext)


```csharp
var a = new Session(HttpContext oInContext)
```

Setea el objeto Context


##### Parámetros del constructor

| Parámetro | Tipo  | Descripción |
| ---- | ---- | ---- |
| **oInContext** | [HttpContext](https://docs.microsoft.com/en-us/dotnet/api/System.Web.HttpContext 'HttpContext')  | Requerido para su uso posterior |


### Lista de métodos

| Método | Descripción |
| ---- | ---- |
| [GetSessionValue(String,Boolean)](#getsessionvalue) | Obtiene las variables de "Session" de Artikos |


#### GetSessionValue

Obtiene las variables de "Session" de Artikos

```csharp
GetSessionValue(String SessionVar, Boolean urlDecode)
```


###### Parámetros

| Parámetro | Tipo  | Descripción |
| ---- | ---- | ---- |
| **SessionVar** | [String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'String') | Nombre de la variable |
| **urlDecode** | [Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'Boolean') | Decodificación de URL (true por defecto) |


##### Retorna

String

## TypeMime

Namespace: Atk.Lib.Streaming

Enum con Type-MIME's para uso en XS_Uploader's

