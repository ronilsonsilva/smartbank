class ClienteSelfieInputModel {
  String imageBase64;

  ClienteSelfieInputModel({this.imageBase64});

  ClienteSelfieInputModel.fromJson(Map<String, dynamic> json) {
    imageBase64 = json['imageBase64'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['imageBase64'] = this.imageBase64;
    return data;
  }
}
