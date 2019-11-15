# PdaNetApi
API de comunicación para dispositivos portables a través de MTP y ActiveSync.

### 1. Overview

Este programa por defecto busca en el dispositivo PDA Zebra MC330K en la ruta **"Internal shared storage\DCIM"**
> **Psdt:** El PDA debe estar configurado en el idioma Inglés.

### 2. Comandos

Estos comandos se utilizan para activar las **acciones(enviar, traer, buscar, borrar)** que tiene el **PdaNetApi**, de esta manera se comunica el PDA y la PC.

| Comando | Parametros                                 | Descripción                             |
| ------  | ------------------------------------------ | --------------------------------------- |
| enviar  | [rutaPC] [nombreArchivoPC] [nombreArchivo] | Envia archivos de la PC al PDA          |
| traer   | [rutaPC] [nombreArchivo]                   | Transfiere los archivos del PDA a la PC |
| buscar  | [nombreArchivo]                            | Busca en el archivo dentro del PDA      |
| borrar  | [nombreArchivo]                            | Borra el archivo en el PDA              |

### 3. Ejemplos
#### - Enviar
Enviar archivos de la PC al Dispositivo PDA:
```sh
$ enviar C:\pdas\ eckerd.s3db eckerd.s3db
```

#### - Traer
Traer archivos del PDA a la PC:
```sh
$ traer C:\pdas\ myArchivo.txt
```

#### - Buscar
Busca archivos dentro del dispositivo PDA:
```sh
$ buscar myArchivo.txt
```

#### - Borrar
Elimina los archivos dentro del PDA:
```sh
$ borrar myArchivo.txt
```