# PdaNetApi
API de comunicación para dispositivos portables a través de MTP y ActiveSync.

### 1. Overview

Este programa por defecto busca en el dispositivo PDA Zebra MC330K en la ruta **"Internal shared storage\DCIM"**
> **Psdt:** El PDA debe estar configurado en el idioma Inglés.

### 2. Comandos

Estos comandos se utilizan para activar las **acciones(enviar, traer, buscar, borrar)** que tiene el **PdaNetApi**, de esta manera se comunica el PDA y la PC.

| Comando | Parametros                                 | Descripción                             |
| ------  | ------------------------------------------ | --------------------------------------- |
|verificar| [SistemaOperativo] (W: Windows, A: Android)| Verifica si existe algún dispositivo conectado|
| enviar  | [rutaPC] [nombreArchivoPC] [nombreArchivo] | Envia archivos de la PC al PDA          |
| traer   | [rutaPC] [nombreArchivo]                   | Transfiere los archivos del PDA a la PC |
| buscar  | [nombreArchivo]                            | Busca en el archivo dentro del PDA      |
| borrar  | [nombreArchivo]                            | Borra el archivo en el PDA              |

### 3. Ejemplos

#### - Verificar
Verifica si existe algún dispositivo PDA conectado a la PC:
```sh
$ PdaNetApi.exe verificar A
```

#### - Enviar
Enviar archivos de la PC al Dispositivo PDA:
```sh
$ PdaNetApi.exe enviar C:\pdas\ myArchivo.txt myArchivo.txt
```

#### - Traer
Traer archivos del PDA a la PC:
```sh
$ PdaNetApi.exe traer C:\pdas\ myArchivo.txt
```

#### - Buscar
Busca archivos dentro del dispositivo PDA:
```sh
$ PdaNetApi.exe buscar myArchivo.txt
```

#### - Borrar
Elimina los archivos dentro del PDA:
```sh
$ PdaNetApi.exe borrar myArchivo.txt
```