import './css/site.css';
import 'bootstrap';
import * as ko from 'knockout';

ko.applyBindings({
    VisitorsLogbook: ko.observable<string>(
        (document.getElementById('VisitorsLogbook') as HTMLInputElement).value)
});