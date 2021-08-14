import Enzyme from 'enzyme';
import Adapter from 'enzyme-adapter-react-16';
import { JSDOM } from 'jsdom'

Enzyme.configure({ adapter: new Adapter() });
var jsdom = new JSDOM('');
global.document = jsdom.window.document;
global.window = jsdom.window;