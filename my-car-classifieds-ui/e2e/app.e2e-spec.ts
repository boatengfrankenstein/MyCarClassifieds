import { MyCarClassifiedsUiPage } from './app.po';

describe('my-car-classifieds-ui App', () => {
  let page: MyCarClassifiedsUiPage;

  beforeEach(() => {
    page = new MyCarClassifiedsUiPage();
  });

  it('should display welcome message', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('Welcome to app!!');
  });
});
