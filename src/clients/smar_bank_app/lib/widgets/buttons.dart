// ignore: must_be_immutable
import 'package:SmarBank/utils/Constantes.dart';
import 'package:SmarBank/utils/colors.dart';
import 'package:flutter/material.dart';
import 'package:nb_utils/nb_utils.dart';

import 'app_widgets.dart';

class Button extends StatefulWidget {
  static String tag = '/Button';
  var textContent;
  VoidCallback onPressed;
  var isStroked = false;
  var height = 50.0;
  var radius = 5.0;

  Button(
      {@required this.textContent,
      @required this.onPressed,
      this.isStroked = false,
      this.height = 45.0,
      this.radius = 5.0});

  @override
  ButtonState createState() => ButtonState();
}

class ButtonState extends State<Button> {
  @override
  Widget build(BuildContext context) {
    return GestureDetector(
      onTap: widget.onPressed,
      child: Container(
        height: widget.height,
        padding: EdgeInsets.fromLTRB(16, 4, 16, 4),
        alignment: Alignment.center,
        child: Text(
          widget.textContent.toUpperCase(),
          style: primaryTextStyle(
              color: widget.isStroked ? Primary : app_whitePureColor,
              size: 18,
              fontFamily: fontMedium),
        ).center(),
        decoration: widget.isStroked
            ? boxDecoration(bgColor: Colors.transparent, color: Primary)
            : boxDecoration(bgColor: Secondary, radius: widget.radius),
      ),
    );
  }
}
