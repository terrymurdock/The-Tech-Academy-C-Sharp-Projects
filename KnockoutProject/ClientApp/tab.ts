import './css/site.css';
import 'bootstrap';
import * as ko from 'knockout';

import home from './components/home-page/home-page';
import about from './components/about/about';

ko.components.register('home-page', home);
ko.components.register('about', about);

ko.applyBindings({});