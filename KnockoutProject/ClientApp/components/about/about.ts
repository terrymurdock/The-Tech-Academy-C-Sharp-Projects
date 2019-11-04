import * as ko from 'knockout';
var img = require("../../Images/me.jpg");

class AboutPageViewModel {
    image = img;
}

export default {
    viewModel: AboutPageViewModel,
    template: require('./about.html')
};

