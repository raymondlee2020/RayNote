# RayNote

RayNote 的主要功能在於提供用戶一個安全且方便儲存筆記的個人空間。採用 [Vue-Cli](https://vuejs.org/) 撰寫前端介面，提供良好的使用者體驗；並使用 [Asp.Net Core](https://docs.microsoft.com/zh-tw/aspnet/core)撰寫 Web API以實現服務。


## 開發方式

### 前端介面
```
cd RayNote/ClientApp
npm install
npm run serve
```
or
```
cd RayNote/ClientApp
yarn install
yarn run serve
```

### 後端API
於 Visual Studio 開啟根目錄之 RayNote.sln
使用 F5 開始運行

## 測試方式

#### 整合執行
```
cd RayNote/ClientApp
npm install
npm run build
```
or
```
cd RayNote/ClientApp
yarn install
yarn run build
```
於 Visual Studio 開啟根目錄之 RayNote.sln
使用 F5 開始運行

#### 測試帳號
Account: admin
Password: adminpass

## 專案特色

#### 已實現
- 用戶建立帳戶
- 用戶登入帳戶
- 用戶建立筆記
- 用戶閱覽筆記
- 用戶修改筆記
- 用戶刪除筆記
- 加密用戶密碼以進行傳輸
- 加密用戶密碼以進行儲存
- 用戶登入產生JWT Token供驗證
- 用戶須經驗證以使用服務(一項服務已驗證)

#### 未實現
- 用戶修改密碼
- 用戶可藉由傳輸圖片進行文字紀錄(使用[Azure Service](https://docs.microsoft.com/zh-tw/azure/cognitive-services/computer-vision/quickstarts-sdk/client-library?pivots=programming-language-csharp))
- 建立行動裝置端應用程式

## 待優化
- 用戶端錯誤訊息顯示
- 使用Local Storage進行用戶端資料儲存
- JWT Token攜帶資料擴充
