import 'package:basic_utils/basic_utils.dart';

class FormatUtils {
  static double currencyFromMonayMasked(String value) {
    var s = value.replaceAll(',', '').replaceAll('.', '').substring(3);
    var valueFormat = StringUtils.addCharAtPosition(s, '.', s.length - 2);
    return double.parse(valueFormat);
  }
}
