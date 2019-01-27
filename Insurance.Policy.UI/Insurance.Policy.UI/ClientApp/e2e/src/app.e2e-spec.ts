import { AppPage } from './app.po';

describe('Insurance.Policy.UI App', () => {
  let page: AppPage;

  beforeEach(() => {
    page = new AppPage();
  });

  it('should display application title: Insurance.Policy.UI', () => {
    page.navigateTo();
    expect(page.getAppTitle()).toEqual('Insurance.Policy.UI');
  });
});
