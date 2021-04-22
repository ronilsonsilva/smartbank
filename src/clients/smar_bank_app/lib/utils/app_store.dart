import 'package:flutter/material.dart';
import 'package:mobx/mobx.dart';
import 'package:nb_utils/nb_utils.dart';
import 'package:smar_bank_app/utils/colors.dart';


class AppStore = AppStoreBase with Store;

abstract class AppStoreBase with Store {
  @observable
  bool isDarkModeOn = false;

  @observable
  Color scaffoldBackground;

  @observable
  Color backgroundColor;

  @observable
  Color backgroundSecondaryColor;

  @observable
  Color textPrimaryColor;

  @observable
  Color appColorPrimaryLightColor;

  @observable
  Color textSecondaryColor;

  @observable
  Color appBarColor;

  @observable
  Color iconColor;

  @observable
  Color iconSecondaryColor;

  @observable
  String selectedLanguage = 'en';

  @observable
  var selectedDrawerItem = -1;

  AppStore(){
    //isDarkModeOn = value ?? !isDarkModeOn;
    isDarkModeOn = true;

    if (isDarkModeOn) {
      scaffoldBackground = appBackgroundColorDark;

      appBarColor = cardBackgroundBlackDark;
      backgroundColor = Colors.white;
      backgroundSecondaryColor = Colors.white;
      appColorPrimaryLightColor = cardBackgroundBlackDark;

      iconColor = iconColorPrimary;
      iconSecondaryColor = iconColorSecondary;

      textPrimaryColor = whiteColor;
      textSecondaryColor = Colors.white54;

      textPrimaryColorGlobal = whiteColor;
      textSecondaryColorGlobal = Colors.white54;
      shadowColorGlobal = appShadowColorDark;

      setStatusBarColor(Colors.black);
    } else {
      scaffoldBackground = Colors.white;

      appBarColor = Colors.white;
      backgroundColor = Colors.black;
      backgroundSecondaryColor = appSecondaryBackgroundColor;
      appColorPrimaryLightColor = appColorPrimaryLight;

      iconColor = iconColorPrimaryDark;
      iconSecondaryColor = iconColorSecondaryDark;

      textPrimaryColor = appTextColorPrimary;
      textSecondaryColor = appTextColorSecondary;

      textPrimaryColorGlobal = appTextColorPrimary;
      textSecondaryColorGlobal = appTextColorSecondary;
      shadowColorGlobal = appShadowColor;

      setStatusBarColor(Colors.white);
    }

    //setValue(isDarkModeOnPref, isDarkModeOn);
  }


  @action
  void setLanguage(String aLanguage) => selectedLanguage = aLanguage;

  @action
  void setDrawerItemIndex(int aIndex) {
    selectedDrawerItem = aIndex;
  }
}
