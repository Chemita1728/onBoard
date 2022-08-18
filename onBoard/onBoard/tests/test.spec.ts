import { test, expect } from '@playwright/test';
test('test', async ({ page }) => {
  // Go to http://10.34.1.43:2080/
  await page.goto('http://10.34.1.43:2080/');
  // Click text=Button
  await page.locator('text=Button').click();
  // Click text=Button
  await page.locator('text=Button').click();
  // Click text=Button
  await page.locator('text=Button').click();
  // Click a:has-text("Hour Page")
  await page.locator('a:has-text("Hour Page")').click();
  await expect(page).toHaveURL('http://10.34.1.43:2080/Users');
  // Click text=Next
  await page.locator('text=Next').click();
  await expect(page).toHaveURL('http://10.34.1.43:2080/Users?pageNumber=2');
  // Click text=Previous
  await page.locator('text=Previous').click();
  await expect(page).toHaveURL('http://10.34.1.43:2080/Users?pageNumber=1');
  // Click text=Home
  await page.locator('text=Home').click();
  await expect(page).toHaveURL('http://10.34.1.43:2080/');
  // Click a:has-text("onBoard")
  await page.locator('a:has-text("onBoard")').click();
  await expect(page).toHaveURL('http://10.34.1.43:2080/');
  // Click text=Hello, Armando Bronca Segura
  await page.locator('text=Hello, Armando Bronca Segura').click();
  // Click ul >> text=Privacy
  await page.locator('ul >> text=Privacy').click();
  await expect(page).toHaveURL('http://10.34.1.43:2080/Home/Privacy');
  // Click text=Hour Page
  await page.locator('text=Hour Page').click();
  await expect(page).toHaveURL('http://10.34.1.43:2080/Users');
});