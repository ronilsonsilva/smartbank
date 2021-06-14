import 'dart:convert';
import 'dart:io';

import 'package:SmarBank/models/cliente/cliente_selfie_inputmodel.dart';
import 'package:SmarBank/services/clienteService.dart';
import 'package:SmarBank/utils/colors.dart';
import 'package:camera/camera.dart';
import 'package:flutter/material.dart';

// A screen that allows users to take a picture using a given camera.
class TakePictureScreen extends StatefulWidget {
  final CameraDescription camera;

  const TakePictureScreen(this.camera);

  @override
  TakePictureScreenState createState() => TakePictureScreenState();
}

class TakePictureScreenState extends State<TakePictureScreen> {
  bool requestEmAndamento = false;
  CameraController _controller;
  Future<void> _initializeControllerFuture;
  final _clienteService = ClienteService();
  final snackBarSucesso =
      SnackBar(content: Text('Selfie enviada com sucesso!'));
  final snackBarErro = SnackBar(content: Text('Falha ao enviar selfie!'));

  @override
  void initState() {
    super.initState();
    // To display the current output from the Camera,
    // create a CameraController.
    _controller = CameraController(
      // Get a specific camera from the list of available cameras.
      widget.camera,
      // Define the resolution to use.
      ResolutionPreset.medium,
    );

    // Next, initialize the controller. This returns a Future.
    _initializeControllerFuture = _controller.initialize();
  }

  @override
  void dispose() {
    // Dispose of the controller when the widget is disposed.
    _controller.dispose();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text("Adicionar Selfie",
            style: TextStyle(color: TextColorWhite, fontSize: 20)),
        centerTitle: true,
        backgroundColor: app_palColor,
      ),
      backgroundColor: app_Background,
      body: FutureBuilder<void>(
        future: _initializeControllerFuture,
        builder: (context, snapshot) {
          if (snapshot.connectionState == ConnectionState.done) {
            // If the Future is complete, display the preview.
            return CameraPreview(_controller);
          } else {
            // Otherwise, display a loading indicator.
            return const Center(child: CircularProgressIndicator());
          }
        },
      ),
      floatingActionButton: FloatingActionButton(
        // Provide an onPressed callback.
        onPressed: () async {
          // Take the Picture in a try / catch block. If anything goes wrong,
          // catch the error.
          try {
            setState(() {
              this.requestEmAndamento = true;
            });

            // Ensure that the camera is initialized.
            await _initializeControllerFuture;

            // Attempt to take a picture and get the file `image`
            // where it was saved.
            final image = await _controller.takePicture();
            var inputModel = ClienteSelfieInputModel();
            var imageBytes = await image.readAsBytes();
            inputModel.imageBase64 = base64Encode(imageBytes);
            var fotoEnviada =
                await this._clienteService.salvarSelfie(inputModel);

            setState(() {
              this.requestEmAndamento = false;
              if (fotoEnviada) {
                ScaffoldMessenger.of(context)
                    .showSnackBar(this.snackBarSucesso);
                Navigator.pop(context);
              } else {
                ScaffoldMessenger.of(context).showSnackBar(this.snackBarErro);
              }
            });
          } catch (e) {
            // If an error occurs, log the error to the console.
            print(e);
            setState(() {
              this.requestEmAndamento = false;
            });
          }
        },
        child: this.requestEmAndamento
            ? CircularProgressIndicator(
                semanticsLabel: "Enviando...",
              )
            : const Icon(Icons.camera_alt),
        backgroundColor: app_palColor,
      ),
    );
  }
}

// A widget that displays the picture taken by the user.
class DisplayPictureScreen extends StatelessWidget {
  final String imagePath;

  const DisplayPictureScreen({this.imagePath});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: const Text('Display the Picture')),
      // The image is stored as a file on the device. Use the `Image.file`
      // constructor with the given path to display the image.
      body: Image.file(File(imagePath)),
    );
  }
}
