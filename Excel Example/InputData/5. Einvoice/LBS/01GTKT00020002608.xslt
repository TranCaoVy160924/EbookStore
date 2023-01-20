<xsl:stylesheet xmlns:hnx="http://www.w3.org/2000/09/xmldsig#" xmlns:exsl="http://exslt.org/common" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:ex="http://exslt.org/dates-and-times" xmlns:inv="http://laphoadon.gdt.gov.vn/2014/09/invoicexml/v1" version="1.0" extension-element-prefixes="ex">
	<xsl:output method="html" />
	<xsl:variable name="version" select="'2.0.5'" />
	<xsl:variable name="LoaiThueSuatHoaDon" select="'MOT_THUE_SUAT'" />
	<xsl:variable name="LoaiTrangHoaDon" select="'NHIEU_TRANG'" />
	<xsl:template name="scriptPage">
		
	</xsl:template>
	<xsl:template name="TemplateBackground">
		<div class="textThaiSonRight">
			<div class="text">(Xuất bởi phần mềm EInvoice, Công ty TNHH Phát triển công nghệ Thái Sơn  - MST: 0101300842 - www.einvoice.vn)</div>
		</div>
		<xsl:if test="inv:invoiceData/inv:phatHanh = 'true'">
			<img class="phathanh" src="data:image/svg+xml;base64,PHN2ZyBpZD0iTGF5ZXJfMSIgZGF0YS1uYW1lPSJMYXllciAxIiB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHZpZXdCb3g9IjAgMCAzODEuNjYgNjEuMiI+PGRlZnM+PHN0eWxlPi5jbHMtMXtmaWxsOiM1ZDVkNWQ7fTwvc3R5bGU+PC9kZWZzPjx0aXRsZT5pY29uPC90aXRsZT48cGF0aCBjbGFzcz0iY2xzLTEiIGQ9Ik0xMC4yNiw3LjcsMjIuMTUsMzkuMywzNCw3LjdoOS4yNlY0OC45M0gzNi4xNFYzNS4zNGwuNzEtMTguMThMMjQuNjcsNDguOTNIMTkuNTVMNy40LDE3LjE4bC43MSwxOC4xNlY0OC45M0gxVjcuN1oiLz48cGF0aCBjbGFzcz0iY2xzLTEiIGQ9Ik02OS4zOSw0OC45M2ExMC44MSwxMC44MSwwLDAsMS0uNzktMi44NiwxMC42OSwxMC42OSwwLDAsMS04LDMuNDNBMTAuODIsMTAuODIsMCwwLDEsNTMsNDYuODZhOC40MSw4LjQxLDAsMCwxLTIuOTEtNi41MSw4LjY5LDguNjksMCwwLDEsMy42NC03LjUycTMuNjMtMi42MSwxMC40LTIuNjJoNC4yMnYtMkE1LjM4LDUuMzgsMCwwLDAsNjcsMjQuMzksNS4zLDUuMywwLDAsMCw2MywyM2E2LDYsMCwwLDAtMy44NSwxLjE4LDMuNjQsMy42NCwwLDAsMC0xLjUsM0g1MC43NmE3LjU5LDcuNTksMCwwLDEsMS42Ny00LjcyQTExLjE1LDExLjE1LDAsMCwxLDU3LDE5YTE2LDE2LDAsMCwxLDYuNDItMS4yNXE1LjM5LDAsOC41OCwyLjcxQTkuNjEsOS42MSwwLDAsMSw3NS4yNSwyOFY0MS44NWExNS41NSwxNS41NSwwLDAsMCwxLjE3LDYuNnYuNDhabTQuNzMtMzQuMi01LjQ2LDAtNS4wNy00LTUsNC01LjQ3LDBMNjEuNTIsOGg0LjE2Wk03MSwxLjdhNC40NSw0LjQ1LDAsMCwxLTEuMjYsMy4xMiw0LDQsMCwwLDEtMywxLjM1LDYuNzEsNi43MSwwLDAsMS0zLjEzLS45NCw2LjQxLDYuNDEsMCwwLDAtMi43Ni0uOTMsMS43OCwxLjc4LDAsMCwwLTEuMzQuNjIsMiwyLDAsMCwwLS41OCwxLjM5bC0yLjU1LS42OEE0LjU1LDQuNTUsMCwwLDEsNTcuNiwyLjQ0YTMuOSwzLjksMCwwLDEsMy0xLjM3LDYuNzQsNi43NCwwLDAsMSwzLC45NCw2LjgxLDYuODEsMCwwLDAsMi44OC45MywxLjg4LDEuODgsMCwwLDAsMS4zNi0uNjVBMiwyLDAsMCwwLDY4LjQuODRaTTYxLjgzLDQ0YTcuNzUsNy43NSwwLDAsMCwzLjg0LTEsNi41Myw2LjUzLDAsMCwwLDIuNy0yLjY2VjM0LjU1SDY0LjY2YTEwLjE0LDEwLjE0LDAsMCwwLTUuNzUsMS4zM0E0LjMsNC4zLDAsMCwwLDU3LDM5LjY0YTQsNCwwLDAsMCwxLjMyLDMuMTZBNS4wOSw1LjA5LDAsMCwwLDYxLjgzLDQ0WiIvPjxwYXRoIGNsYXNzPSJjbHMtMSIgZD0iTTEwMSw0NS45M3EtMywzLjU3LTguNjEsMy41N2MtMy4zMywwLTUuODQtMS03LjU1LTIuOTJzLTIuNTYtNC43Ni0yLjU2LTguNDRWMTguMjloNi44OFYzOC4wNnEwLDUuODQsNC44NCw1LjgzLDUsMCw2Ljc3LTMuNnYtMjJoNi44OFY0OC45M0gxMDEuMloiLz48cGF0aCBjbGFzcz0iY2xzLTEiIGQ9Ik0xNTYsMzMuOTJxMCw3LjExLTMuMjMsMTEuMzRhMTEuMjEsMTEuMjEsMCwwLDEtMTYuNzQuOTJWNjAuNzFoLTYuODhWMTguMjloNi4zNGwuMjksMy4xMUExMC4xMSwxMC4xMSwwLDAsMSwxNDQsMTcuNzJhMTAuNDUsMTAuNDUsMCwwLDEsOC43OSw0LjE4UTE1NiwyNi4wNywxNTYsMzMuNVptLTYuODYtLjU5YTEyLjc2LDEyLjc2LDAsMCwwLTEuODItNy4yOCw2LDYsMCwwLDAtNS4yMy0yLjY5QTYuMzQsNi4zNCwwLDAsMCwxMzYsMjYuODR2MTMuNkE2LjQxLDYuNDEsMCwwLDAsMTQyLjEyLDQ0YTUuOTQsNS45NCwwLDAsMCw1LjE0LTIuNjRDMTQ4LjUsMzkuNTksMTQ5LjExLDM2LjkxLDE0OS4xMSwzMy4zM1oiLz48cGF0aCBjbGFzcz0iY2xzLTEiIGQ9Ik0xNjguNTcsMjEuNjNhMTAuNzksMTAuNzksMCwwLDEsOC41Mi0zLjkxcTkuODEsMCw5Ljk1LDExLjE5djIwaC02Ljg5VjI5LjE2YzAtMi4xMS0uNDUtMy42MS0xLjM3LTQuNDhhNS42Miw1LjYyLDAsMCwwLTQtMS4zMkE2LjY0LDYuNjQsMCwwLDAsMTY4LjU3LDI3VjQ4LjkzaC02Ljg4VjUuNDNoNi44OFoiLz48cGF0aCBjbGFzcz0iY2xzLTEiIGQ9Ik0yMTIuMyw0OC45M2ExMC4zNywxMC4zNywwLDAsMS0uOC0yLjg2LDExLjU1LDExLjU1LDAsMCwxLTE1LjU3Ljc5QTguMzksOC4zOSwwLDAsMSwxOTMsNDAuMzVhOC42OSw4LjY5LDAsMCwxLDMuNjQtNy41MmMyLjQzLTEuNzQsNS44OS0yLjYyLDEwLjQxLTIuNjJoNC4yMnYtMkE1LjQyLDUuNDIsMCwwLDAsMjEwLDI0LjM5YTUuMyw1LjMsMCwwLDAtNC0xLjQzQTYuMDYsNi4wNiwwLDAsMCwyMDIsMjQuMTRhMy42NCwzLjY0LDAsMCwwLTEuNSwzaC02Ljg4YTcuNjUsNy42NSwwLDAsMSwxLjY3LTQuNzJBMTEuMTgsMTEuMTgsMCwwLDEsMTk5Ljg4LDE5YTE1Ljk0LDE1Ljk0LDAsMCwxLDYuNDEtMS4yNXE1LjM5LDAsOC41OCwyLjcxYTkuNjIsOS42MiwwLDAsMSwzLjI5LDcuNlY0MS44NWExNS43MiwxNS43MiwwLDAsMCwxLjE2LDYuNnYuNDhabS03LjU2LTVhNy43NCw3Ljc0LDAsMCwwLDMuODMtMSw2LjYyLDYuNjIsMCwwLDAsMi43MS0yLjY2VjM0LjU1aC0zLjcxYTEwLjEyLDEwLjEyLDAsMCwwLTUuNzUsMS4zMyw0LjI5LDQuMjksMCwwLDAtMS45MywzLjc2LDQsNCwwLDAsMCwxLjMyLDMuMTZBNS4xMiw1LjEyLDAsMCwwLDIwNC43NCw0NFptMy44Mi0zOC41NWg3Ljg0TDIwOC41NiwxNEgyMDNaIi8+PHBhdGggY2xhc3M9ImNscy0xIiBkPSJNMjM0LDEwLjg0djcuNDVoNS40MXY1LjFIMjM0djE3LjFhMy44LDMuOCwwLDAsMCwuNjksMi41NCwzLjIzLDMuMjMsMCwwLDAsMi40OC43OCwxMC41OCwxMC41OCwwLDAsMCwyLjQxLS4yOXY1LjMzYTE3LjE1LDE3LjE1LDAsMCwxLTQuNTMuNjVxLTcuOTMsMC03LjkzLTguNzVWMjMuMzloLTV2LTUuMWg1VjEwLjg0WiIvPjxwYXRoIGNsYXNzPSJjbHMtMSIgZD0iTTI2NS44OCwyMS42M2ExMC43OSwxMC43OSwwLDAsMSw4LjUyLTMuOTFxOS44MSwwLDkuOTQsMTEuMTl2MjBoLTYuODhWMjkuMTZjMC0yLjExLS40Ni0zLjYxLTEuMzctNC40OGE1LjYyLDUuNjIsMCwwLDAtNC0xLjMyQTYuNjQsNi42NCwwLDAsMCwyNjUuODgsMjdWNDguOTNIMjU5VjUuNDNoNi44OFoiLz48cGF0aCBjbGFzcz0iY2xzLTEiIGQ9Ik0zMDkuNjEsNDguOTNhMTAuMzcsMTAuMzcsMCwwLDEtLjgtMi44NiwxMS41NSwxMS41NSwwLDAsMS0xNS41Ny43OSw4LjM5LDguMzksMCwwLDEtMi45Mi02LjUxQTguNjksOC42OSwwLDAsMSwyOTQsMzIuODNxMy42My0yLjYxLDEwLjQxLTIuNjJoNC4yMnYtMmE1LjM4LDUuMzgsMCwwLDAtMS4zNC0zLjgxQTUuMjcsNS4yNywwLDAsMCwzMDMuMiwyM2E2LDYsMCwwLDAtMy44NSwxLjE4LDMuNjQsMy42NCwwLDAsMC0xLjUsM0gyOTFhNy42NSw3LjY1LDAsMCwxLDEuNjctNC43MkExMS4xOCwxMS4xOCwwLDAsMSwyOTcuMTksMTlhMTUuOTQsMTUuOTQsMCwwLDEsNi40MS0xLjI1cTUuMzgsMCw4LjU4LDIuNzFhOS42Miw5LjYyLDAsMCwxLDMuMjksNy42VjQxLjg1YTE1LjU2LDE1LjU2LDAsMCwwLDEuMTYsNi42di40OFpNMzA3LjQyLDE0SDMwMS43bC03LjY0LTguNThoNy44NFpNMzAyLDQ0YTcuNzUsNy43NSwwLDAsMCwzLjg0LTEsNi42Miw2LjYyLDAsMCwwLDIuNzEtMi42NlYzNC41NWgtMy43MWExMC4xMiwxMC4xMiwwLDAsMC01Ljc1LDEuMzMsNC4yOSw0LjI5LDAsMCwwLTEuOTMsMy43Niw0LDQsMCwwLDAsMS4zMiwzLjE2QTUuMTEsNS4xMSwwLDAsMCwzMDIsNDRaIi8+PHBhdGggY2xhc3M9ImNscy0xIiBkPSJNMzI5LjA2LDE4LjI5bC4yLDMuNTRhMTEsMTEsMCwwLDEsOC45Mi00LjExcTkuNTcsMCw5Ljc0LDExVjQ4LjkzSDM0MVYyOS4wOGE2LjMzLDYuMzMsMCwwLDAtMS4yNi00LjMyLDUuMzEsNS4zMSwwLDAsMC00LjEyLTEuNCw2LjYxLDYuNjEsMCwwLDAtNi4yLDMuNzd2MjEuOGgtNi44OFYxOC4yOVoiLz48cGF0aCBjbGFzcz0iY2xzLTEiIGQ9Ik0zNjEuNzEsMjEuNjNhMTAuOCwxMC44LDAsMCwxLDguNTMtMy45MXE5Ljc5LDAsOS45NCwxMS4xOXYyMEgzNzMuM1YyOS4xNmMwLTIuMTEtLjQ2LTMuNjEtMS4zOC00LjQ4YTUuNTksNS41OSwwLDAsMC00LTEuMzJBNi42NCw2LjY0LDAsMCwwLDM2MS43MSwyN1Y0OC45M2gtNi44OFY1LjQzaDYuODhaIi8+PC9zdmc+" />
		</xsl:if>
		<div id="khungNenLogo" class="khungNenLogo draggable" style="position: relative; z-index: -2; left: -14px; top: -27px;">
			<img id="nenLogo" data-src="anhNenLogo" class="resizable logo nenLogo" data-style="styleNenLogo" reduced="">
				<xsl:attribute name="src">
					<xsl:value-of select="$anhNenLogo" />
				</xsl:attribute>
				<xsl:attribute name="style">
					<xsl:value-of select="$styleNenLogo" />
				</xsl:attribute>
			</img>
		</div>
		<div id="khungNenHoaVan" class="khungNenHoaVan draggable" style="position:relative;z-index:-3;">
			<img id="anhNenHoaVan" data-src="anhHoaVan" class="anhNenHoaVan resizable" data-style="styleNenHoaVan">
				<xsl:attribute name="data-ma-anh">
					<xsl:value-of select="$maAnhNenThuVien" />
				</xsl:attribute>
				<xsl:attribute name="src">
					<xsl:value-of select="$anhHoaVan" />
				</xsl:attribute>
				<xsl:attribute name="style">
					<xsl:value-of select="$styleNenHoaVan " />
				</xsl:attribute>
			</img>
		</div>
		<img id="anhVienHoaDon" class="anhVienHoaDon" data-src="anhVien">
			<xsl:attribute name="src">
				<xsl:value-of select="$anhVien " />
			</xsl:attribute>
			<xsl:attribute name="style">
				<xsl:value-of select="$styleAnhVien" />
			</xsl:attribute>
		</img>
	</xsl:template>
	<xsl:template name="TemplateLogo">
		<div id="khungLogo" class="khungLogo">
			<img data-src="anhLogo" id="anhLogo" data-style="styleLogo" reduced="">
				<xsl:attribute name="class">
          logo resizable
				</xsl:attribute>
				<xsl:attribute name="src">
					<xsl:value-of select="$anhLogo" />
				</xsl:attribute>
				<xsl:attribute name="style">
					<xsl:value-of select="$styleLogo" />
				</xsl:attribute>
			</img>
		</div>
	</xsl:template>
	<xsl:template name="TemplateSeller">
		<div class="infoGroup seller khungSmall" data-group="seller">
			<div class="infoContainer" data-style="txt_sellerDisplayNameContainer">
				<div>
					<span class="styleChange onlyChangeStyle" style="font-weight:bold;" data-style="sellerLegalNameStyle" data-val="txt_sellerLegalName">
						<xsl:value-of disable-output-escaping="yes" select="inv:invoiceData/inv:sellerLegalName" />
					</span>
				</div>
			</div>
			<div class="infoContainer" data-style="txt_sellerTaxCodeContainer">
				<div class="colLabel" onkeyup="drawDongKe(this)">
					<span class="editable styleChange" data-style="txt_sellerTaxCode" data-label="txt_sellerTaxCode">Mã số thuế</span>
					<span class="SONG_NGU editable styleChange" style="font-style:italic;" data-style="txt_sellerTaxCode_SN" data-label="txt_sellerTaxCode_SN">(Tax code)</span>
				</div>
				<span class="colon">:</span>
				<div class="colVal">
					<span class="maSoThue" style="font-weight:bold;" data-val="txt_sellerTaxCode">
						<xsl:value-of select="inv:invoiceData/inv:sellerTaxCode" />
					</span>
					<div class="dottedLineContainer" data-line="sellerTaxCode_Line">
						<span class="dottedLine styleChange" data-style="sellerTaxCode_Line" style="top:17.5px;width:463px;left:69px;" />
					</div>
				</div>
			</div>
			<div class="infoContainer" data-style="txt_sellerAddressLineContainer">
				<div class="colLabel" onkeyup="drawDongKe(this)">
					<span class="editable styleChange" data-style="txt_sellerAddressLine" data-label="txt_sellerAddressLine">Địa chỉ</span>
					<span class="SONG_NGU editable styleChange" style="font-style:italic;" data-style="txt_sellerAddressLine_SN" data-label="txt_sellerAddressLine_SN">(Address)</span>
				</div>
				<span class="colon">:</span>
				<div class="colVal">
					<span data-val="txt_sellerAddressLine">
						<xsl:value-of disable-output-escaping="yes" select="inv:invoiceData/inv:sellerAddressLine" />
					</span>
					<div class="dottedLineContainer" data-line="sellerAddress_Line">
						<span class="dottedLine styleChange" data-style="sellerAddress_Line" style="top:17.5px;width:484px;left:48px;" />
					</div>
				</div>
			</div>
			<div class="infoContainer styleChange" style="display: none;" data-style="txt_sellerWebsiteContainer">
				<div class="colLabel" onkeyup="drawDongKe(this)">
					<span class="editable styleChange" data-style="txt_sellerWebsite" data-label="txt_sellerWebsite">Website</span>
					<span class="SONG_NGU editable styleChange" style="font-style:italic;padding-left:0;" data-style="txt_sellerWebsite_SN" data-label="txt_sellerWebsite_SN" />
				</div>
				<span class="colon">:</span>
				<div class="colVal">
					<span data-val="txt_sellerWebsite">
						<xsl:value-of select="inv:invoiceData/inv:sellerWebsite" />
					</span>
					<div class="dottedLineContainer" data-line="sellerWebsite_Line">
						<span class="dottedLine styleChange" data-style="sellerWebsite_Line" style="top:17.5px;width:0px;left:0px;" />
					</div>
				</div>
			</div>
			<div class="infoContainer styleChange" style="width:50%;" data-style="txt_sellerPhoneNumberContainer">
				<div class="colLabel" onkeyup="drawDongKe(this)">
					<span class="editable styleChange" data-style="txt_sellerPhoneNumber" data-label="txt_sellerPhoneNumber">Điện thoại</span>
					<span class="SONG_NGU editable styleChange" style="font-style:italic;" data-style="txt_sellerPhoneNumber_SN" data-label="txt_sellerPhoneNumber_SN">(Tel)</span>
				</div>
				<span class="colon">:</span>
				<div class="colVal">
					<span data-val="txt_sellerPhoneNumber">
						<xsl:value-of select="inv:invoiceData/inv:sellerPhoneNumber" />
					</span>
					<div class="dottedLineContainer" data-line="sellerPhoneNumber_Line">
						<span class="dottedLine styleChange" data-style="sellerPhoneNumber_Line" style="top:17.5px;width:200px;left:66px;" />
					</div>
				</div>
			</div>
			<div class="infoContainer styleChange dongKhongThangHang" style="width:50%;" data-style="txt_sellerFaxNumberContainer">
				<div class="colLabel" onkeyup="drawDongKe(this)">
					<span class="editable styleChange" data-style="txt_sellerFaxNumber" data-label="txt_sellerFaxNumber">Fax</span>
					<span class="SONG_NGU editable styleChange" style="font-style:italic;padding-left:0;" data-style="txt_sellerFaxNumber_SN" data-label="txt_sellerFaxNumber_SN" />
				</div>
				<span class="colon">:</span>
				<div class="colVal">
					<span data-val="txt_sellerFaxNumber">
						<xsl:value-of select="inv:invoiceData/inv:sellerFaxNumber" />
					</span>
					<div class="dottedLineContainer" data-line="sellerFaxNumber_Line">
						<span class="dottedLine styleChange" data-style="sellerFaxNumber_Line" style="top:17.5px;width:238px;left:28px;" />
					</div>
				</div>
			</div>
			<div class="infoContainer styleChange" data-style="txt_sellerBankAccountContainer">
				<div class="colLabel" onkeyup="drawDongKe(this)">
					<span class="editable styleChange" data-style="txt_sellerBankAccount" data-label="txt_sellerBankAccount">Số tài khoản</span>
					<span>
						<i class="SONG_NGU editable styleChange" data-style="txt_sellerBankAccount_SN" data-label="txt_sellerBankAccount_SN">(Bank A/C)</i>
					</span>
				</div>
				<span class="colon">:</span>
				<div class="colVal">
					<span data-val="txt_sellerBankAccount">
						<xsl:value-of select="inv:invoiceData/inv:sellerBankAccount" />
					</span>
					<xsl:if test="normalize-space(inv:invoiceData/inv:sellerBankAccount)">
						<span class="pr5" />
						<span class="editable styleChange" data-style="txt_centerSellerBank" data-label="txt_centerSellerBank">tại</span>
						<span class="SONG_NGU editable styleChange" style="font-style:italic;" data-style="txt_centerSellerBank_SN" data-label="txt_centerSellerBank_SN">(at)</span>
						<span class="pr5" />
						<span data-val="txt_sellerBankName">
							<xsl:value-of disable-output-escaping="yes" select="inv:invoiceData/inv:sellerBankName" />
						</span>
					</xsl:if>
					<div class="dottedLineContainer" data-line="sellerBank_Line">
						<span class="dottedLine styleChange" data-style="sellerBank_Line" style="top:17.5px;width:455px;left:77px;" />
						<span class="dottedLine styleChange" data-style="sellerBank_Line1" style="left:0;top:38.5px;width:100%;" />
					</div>
				</div>
			</div>
		</div>
	</xsl:template>
	<xsl:template name="TemplateBuyer">
		<div class="infoGroup buyer" data-group="buyer">
			<div class="infoContainer" data-style="txt_buyerDisplayNameContainer">
				<div class="colLabel" onkeyup="drawDongKe(this)">
					<span class="editable styleChange" data-style="txt_buyerDisplayName" data-label="txt_buyerDisplayName">Người mua hàng</span>
					<span class="SONG_NGU editable styleChange" style="font-style:italic;" data-style="txt_buyerDisplayName_SN" data-label="txt_buyerDisplayName_SN">(Buyer)</span>
				</div>
				<span class="colon">:</span>
				<div class="colVal">
					<span data-val="txt_buyerDisplayName">
						<xsl:value-of select="inv:invoiceData/inv:buyerDisplayName" />
					</span>
					<div class="dottedLineContainer" data-line="buyerDisplayName_Line">
						<span class="dottedLine styleChange" data-style="buyerDisplayName_Line" style="top:17.5px;width:616px;left:101px;" />
					</div>
				</div>
			</div>
			<div class="infoContainer" data-style="ext_buyerLegalNameContainer">
				<div class="colLabel" onkeyup="drawDongKe(this)">
					<span class="editable styleChange" data-style="ext_buyerLegalName" data-label="ext_buyerLegalName">Tên đơn vị</span>
					<span class="SONG_NGU editable styleChange" style="font-style:italic;" data-style="txt_buyerLegalName_SN" data-label="txt_buyerLegalName_SN">(Company)</span>
				</div>
				<span class="colon">:</span>
				<div class="colVal">
					<span data-val="txt_buyerLegalName">
						<xsl:value-of disable-output-escaping="yes" select="inv:invoiceData/inv:buyerLegalName" />
					</span>
					<div class="dottedLineContainer" data-line="buyerLegalName_Line">
						<span class="dottedLine styleChange" data-style="buyerLegalName_Line" style="top:17.5px;width:649px;left:68px;" />
					</div>
				</div>
			</div>
			<div class="infoContainer" data-style="txt_buyerTaxCodeContainer">
				<div class="colLabel" onkeyup="drawDongKe(this)">
					<span class="editable styleChange" data-style="txt_buyerTaxCode" data-label="txt_buyerTaxCode">Mã số thuế</span>
					<span class="SONG_NGU editable styleChange" style="font-style:italic;" data-style="txt_buyerTaxCode_SN" data-label="txt_buyerTaxCode_SN">(Tax code)</span>
				</div>
				<span class="colon">:</span>
				<div class="colVal">
					<span data-val="txt_buyerTaxCode">
						<xsl:value-of select="inv:invoiceData/inv:buyerTaxCode" />
					</span>
					<div class="dottedLineContainer" data-line="buyerTaxCode_Line">
						<span class="dottedLine styleChange" data-style="buyerTaxCode_Line" style="top:17.5px;width:648px;left:69px;" />
					</div>
				</div>
			</div>
			<div class="infoContainer" data-style="txt_buyerAddressLineContainer">
				<div class="colLabel" onkeyup="drawDongKe(this)">
					<span class="editable styleChange" data-style="txt_buyerAddressLine" data-label="txt_buyerAddressLine">Địa chỉ</span>
					<span class="SONG_NGU editable styleChange" style="font-style:italic;" data-style="txt_buyerAddressLine_SN" data-label="txt_buyerAddressLine_SN">(Address)</span>
				</div>
				<span class="colon">:</span>
				<div class="colVal">
					<xsl:attribute name="style">
							min-height:<xsl:value-of select="$lineHeight * 2" />px;
					</xsl:attribute>
					<span data-val="txt_buyerAddressLine">
						<xsl:value-of disable-output-escaping="yes" select="inv:invoiceData/inv:buyerAddressLine" />
					</span>
					<div class="dottedLineContainer" data-line="buyerAddress_Line">
						<span class="dottedLine styleChange" data-style="buyerAddress_Line" style="top:17.5px;width:669px;left:48px;" />
						<span class="dottedLine styleChange" data-style="buyerAddress_Line1" style="left:0;top:38.5px;width:100%;" />
					</div>
				</div>
			</div>
			<div class="infoContainer sys extension styleChange" style="width:50%;" data-style="txt_paymentMethodNameContainer" data-type="4">
				<div class="colLabel" onkeyup="drawDongKe(this)">
					<span class="editable styleChange" data-style="txt_paymentMethodName" data-label="txt_paymentMethodName">Hình thức thanh toán</span>
					<span class="SONG_NGU editable styleChange" style="font-style:italic;" data-style="txt_paymentMethodName_SN" data-label="txt_paymentMethodName_SN">(Payment method)</span>
				</div>
				<span class="colon">:</span>
				<div class="colVal">
					<span data-val="txt_paymentMethodName" data-path="paymentMethodName">
						<xsl:value-of disable-output-escaping="yes" select="inv:invoiceData/inv:payments/inv:payment/inv:paymentMethodName" />
					</span>
					<div class="dottedLineContainer" data-line="paymentMethodName_Line">
						<span class="dottedLine styleChange" data-style="paymentMethodName_Line" style="top:17.5px;width:234px;left:125px;" />
					</div>
				</div>
			</div>
			<div class="infoContainer sys extension dongKhongThangHang styleChange" style="width:50%;" data-style="txt_buyerBankAccountContainer" data-type="4">
				<div class="colLabel" onkeyup="drawDongKe(this)">
					<span class="editable styleChange" data-style="txt_buyerBankAccount" data-label="txt_buyerBankAccount">Số tài khoản</span>
					<span class="SONG_NGU editable styleChange" style="font-style:italic;" data-style="txt_buyerBankAccount_SN" data-label="txt_buyerBankAccount_SN">(Bank A/C)</span>
				</div>
				<span class="colon">:</span>
				<div class="colVal">
					<span data-val="txt_buyerBankAccount" data-path="buyerBankAccount">
						<xsl:value-of select="inv:invoiceData/inv:buyerBankAccount" />
					</span>
					<xsl:if test="normalize-space(inv:invoiceData/inv:buyerBankAccount)">
						<span class="pr5" />
						<span class="editable styleChange" data-style="txt_centerBuyerBank" data-label="txt_centerBuyerBank">tại</span>
						<span class="SONG_NGU editable styleChange" data-style="txt_centerBuyerBank_SN" data-label="txt_centerBuyerBank_SN">(at)</span>
						<span class="pr5" />
						<span data-val="txt_buyerBankName" data-path="buyerBankName">
							<xsl:value-of disable-output-escaping="yes" select="inv:invoiceData/inv:buyerBankName" />
						</span>
					</xsl:if>
					<div class="dottedLineContainer" data-line="buyerBankAccount_Line">
						<span class="dottedLine styleChange" data-style="buyerBankAccount_Line" style="top:17.5px;width:281px;left:77px;" />
					</div>
				</div>
			</div>
		</div>
	</xsl:template>
	<xsl:template name="Template_Code_Series_invoiceNumber">
		<div class="infoGroup">
			<div class="infoContainer" data-style="txt_templateCodeContainer">
				<span class="editable styleChange" data-style="txt_templateCode" data-label="txt_templateCode">Mẫu số</span>
				<span class="SONG_NGU editable styleChange" style="font-style:italic;" data-style="txt_templateCode_SN" data-label="txt_templateCode_SN">(Form)</span>
				<span class="pr3">:</span>
				<span style="font-weight:bold;" data-val="txt_templateCode">
					<xsl:value-of select="inv:invoiceData/inv:templateCode" />
				</span>
			</div>
			<div class="infoContainer" data-style="txt_invoiceSeriesContainer">
				<span class="editable styleChange" data-style="txt_invoiceSeries" data-label="txt_invoiceSeries">Ký hiệu</span>
				<span class="SONG_NGU editable styleChange" style="font-style:italic;" data-style="txt_invoiceSeries_SN" data-label="txt_invoiceSeries_SN">(Serial)</span>
				<span class="pr3">:</span>
				<span style="font-weight:bold;" data-val="txt_invoiceSeries">
					<xsl:value-of select="inv:invoiceData/inv:invoiceSeries" />
				</span>
			</div>
			<div class="infoContainer" data-style="txt_invoiceNumberContainer">
				<span class="editable styleChange" data-style="txt_invoiceNumber" data-label="txt_invoiceNumber">Số</span>
				<span class="SONG_NGU editable styleChange" style="font-style:italic;" data-style="txt_invoiceNumber_SN" data-label="txt_invoiceNumber_SN">(No.)</span>
				<span class="pr3">:</span>
				<span class="eivNumber" data-val="txt_invoiceNumber">
					<xsl:choose>
						<xsl:when test="inv:invoiceData/inv:phatHanh = 'true'">0000000</xsl:when>
						<xsl:otherwise>
							<xsl:value-of select="inv:invoiceData/inv:invoiceNumber" />
						</xsl:otherwise>
					</xsl:choose>
				</span>
			</div>
		</div>
	</xsl:template>
	<xsl:template name="TemplateInvoiceInformation" match="inv:invoice">
		<xsl:variable name="issuedDate" select="inv:invoiceData/inv:invoiceIssuedDate" />
		<xsl:variable name="invTypeFull" select="inv:invoiceData/inv:invoiceType" />
		<xsl:variable name="loaiHoaDon" select="substring($invTypeFull, 1, 2)" />
		<div class="invoiceNameContainer" data-style="txt_invoiceName">
			<div class="invName">
				<xsl:value-of select="inv:invoiceData/inv:invoiceName" />
			</div>
			<xsl:if test="$loaiHoaDon = '07'">
				<div class="SONG_NGU invNameSN styleChange onlyChangeStyle" style="font-style:italic" data-style="txt_invoiceName_SN">(SALE INVOICE)</div>
			</xsl:if>
			<xsl:if test="$loaiHoaDon = '02'">
				<div class="SONG_NGU invNameSN styleChange onlyChangeStyle" style="font-style:italic" data-style="txt_invoiceName_SN">(SALE INVOICE)</div>
			</xsl:if>
			<xsl:if test="$loaiHoaDon = '01'">
				<div class="SONG_NGU invNameSN styleChange onlyChangeStyle" style="font-style:italic" data-style="txt_invoiceName_SN">(VAT INVOICE)</div>
			</xsl:if>
			<div class="customInvName styleChange editable" data-label="customInvName" data-style="customInvName" data-val="customInvName" />
			<div class="invNameDetail editable styleChange" data-label="invNameDetail" data-style="invNameDetail" />
			<div class="SONG_NGU invNameDetailSN editable styleChange" data-label="invNameDetailSN" data-style="invNameDetailSN">
				<xsl:if test="$loaiHoaDon = '07'">(Used for Organisation, personally in district brown tariff)</xsl:if>
			</div>
		</div>
		<div class="issuedDate-printFlag">
			<div class="issuedDate">
				<xsl:choose>
					<xsl:when test="inv:invoiceData/inv:phatHanh='true'">
						<span>Ngày</span>
						<i class="SONG_NGU">(Date)</i>      
						<span>tháng</span>
						<i class="SONG_NGU">(month)</i>     
						<span>năm</span>
						<i class="SONG_NGU">(year)</i>
					</xsl:when>
					<xsl:otherwise>
						<span>Ngày</span>
						<i class="SONG_NGU pd0">(Date)</i>
						<span class="pl7 pr7">
							<xsl:value-of select="substring($issuedDate, 9, 2)" />
						</span>
						<span>tháng</span>
						<i class="SONG_NGU pd0">(month)</i>
						<span class="pl7 pr7">
							<xsl:value-of select="substring($issuedDate, 6, 2)" />
						</span>
						<span>năm</span>
						<i class="SONG_NGU pd0">(year)</i>
						<span class="pl7 pr7">
							<xsl:value-of select="substring($issuedDate, 1, 4)" />
						</span>
					</xsl:otherwise>
				</xsl:choose>
			</div>
			<div class="printFlag">
				<div class="hoaDonChuyenDoi">
					<span class="fixFont">
						<i>(HÓA ĐƠN CHUYỂN ĐỔI TỪ HÓA ĐƠN ĐIỆN TỬ)</i>
					</span>
					<span class="SONG_NGU fixFont dbl">
						<i>(TRANSFORM INVOICE FROM E-INVOICE)</i>
					</span>
				</div>
				<div class="hoaDonGoc">
					<xsl:choose>
						<xsl:when test="$loaiHoaDon = '03'">
							<span class="fixFont">
								<i>(BẢN THỂ HIỆN CỦA <b>PXKKVCNB</b> ĐIỆN TỬ)</i>
							</span>
						</xsl:when>
						<xsl:otherwise>
							<span class="fixFont">
								<i>(BẢN THỂ HIỆN CỦA HÓA ĐƠN ĐIỆN TỬ)</i>
							</span>
						</xsl:otherwise>
					</xsl:choose>
					<span class="SONG_NGU fixFont dbl">
						<i>(EINVOICE DISPLAY VERSION)</i>
					</span>
				</div>
			</div>
		</div>
		<div class="xoabo">
			<xsl:value-of select="inv:StatusDelete" />
		</div>
	</xsl:template>
	<xsl:template name="TemplateInvoiceInformation_Change" match="inv:invoice">
		<xsl:choose>
			<xsl:when test="normalize-space(inv:invoiceData/inv:adjustmentType) = '3'">
				<div class="col20" style="padding-bottom:5px">
					<b>Thay thế cho hóa đơn điện tử số: </b>
					<span class="border">
						<xsl:value-of select="inv:invoiceData/inv:originalInvoiceId" />
					</span>
					<br />
				</div>
			</xsl:when>
			<xsl:when test="normalize-space(inv:invoiceData/inv:adjustmentType) = '5' and normalize-space(inv:invoiceData/inv:originalInvoiceId)">
				<div class="col20" style="padding-bottom:5px">
					<b>Điều chỉnh cho hóa đơn điện tử số: </b>
					<span class="border">
						<xsl:value-of select="inv:invoiceData/inv:originalInvoiceId" />
					</span>
					<br />
				</div>
			</xsl:when>
			<xsl:when test="normalize-space(inv:invoiceData/inv:adjustmentType) = '7' and normalize-space(inv:invoiceData/inv:originalInvoiceId)">
				<div class="col20" style="padding-bottom:5px">
					<b>Xóa bỏ cho hóa đơn điện tử số: </b>
					<span class="border">
						<xsl:value-of select="inv:invoiceData/inv:originalInvoiceId" />
					</span>
					<br />
				</div>
			</xsl:when>
		</xsl:choose>
	</xsl:template>
	<xsl:template name="BangHang" match="inv:invoice">
		<xsl:variable name="invTypeFull" select="inv:invoiceData/inv:invoiceType" />
		<xsl:variable name="loaiHoaDon" select="substring($invTypeFull, 1, 2)" />
		<xsl:variable name="nguyente" select="inv:invoiceData/inv:currencyCode" />
		<div class="tableContainer">
			<table class="table">
				<thead>
					<tr>
						<th style="width:25px" class="styleChange" data-style="colSTTContainer">
							<span class="editable styleChange" style="font-weight:bold;" data-label="colSTT" data-style="colSTT">STT</span>
							<br />
							<span class="SONG_NGU editable styleChange" style="font-style:italic" data-label="colSTT_SN" data-style="colSTT_SN">(No.)</span>
						</th>
						<th style="width:65px" class="styleChange" data-style="colMaHangContainer">
							<span class="editable styleChange" style="font-weight:bold;" data-label="colMaHang" data-style="colMaHang">Mã hàng</span>
							<br />
							<span class="SONG_NGU editable styleChange" style="font-style:italic" data-label="colMaHang_SN" data-style="colMaHang_SN">(Code)</span>
						</th>
						<th style="width:300px" class="styleChange" data-style="colTenHangContainer">
							<span class="editable styleChange" style="font-weight:bold;" data-label="colTenHang" data-style="colTenHang">Tên hàng hóa, dịch vụ</span>
							<br />
							<span class="SONG_NGU editable styleChange" style="font-style:italic" data-label="colTenHang_SN" data-style="colTenHang_SN">(Description)</span>
						</th>
						<th style="width:55px" class="styleChange" data-style="colDVTContainer">
							<span class="editable styleChange" style="font-weight:bold;" data-label="colDTV" data-style="colDTV">Đơn vị tính</span>
							<br />
							<span class="SONG_NGU editable styleChange" style="font-style:italic" data-label="colDVT_SN" data-style="colDVT_SN">(Unit)</span>
						</th>
						<th style="width:55px" class="styleChange" data-style="colSLContainer">
							<span class="editable styleChange" style="font-weight:bold;" data-label="colSL" data-style="colSL">Số lượng</span>
							<br />
							<span class="SONG_NGU editable styleChange" style="font-style:italic" data-label="colSL_SN" data-style="colSL_SN">(Quantity)</span>
						</th>
						<th style="width:75px" class="styleChange" data-style="colDonGiaContainer">
							<span class="editable styleChange" style="font-weight:bold;" data-label="colDonGia" data-style="colDonGia">Đơn giá</span>
							<br />
							<span class="SONG_NGU editable styleChange" style="font-style:italic" data-label="colDonGia_SN" data-style="colDonGia_SN">(Unit price)</span>
						</th>
						<th style="width:100px" class="styleChange" data-style="colThanhTienContainer">
							<span class="editable styleChange" style="font-weight:bold;" data-label="colThanhTien" data-style="colThanhTien">Thành tiền</span>
							<br />
							<span class="SONG_NGU editable styleChange" style="font-style:italic" data-label="colThanhTien_SN" data-style="colThanhTien_SN">(Amount)</span>
						</th>
						<th style="width:90px" class="styleChange" data-style="colTienThueContainer">
							<span class="editable styleChange" style="font-weight:bold;" data-label="colTienThue" data-style="colTienThue">Tiền thuế</span>
							<br />
							<span class="SONG_NGU editable styleChange" style="font-style:italic" data-label="colTienThue_SN" data-style="colTienThue_SN">(Tax amount)</span>
						</th>
						<th style="width:90px" class="styleChange" data-style="colChietKhauContainer">
							<span class="editable styleChange" style="font-weight:bold;" data-label="colChietKhau" data-style="colChietKhau">Chiết khấu</span>
							<br />
							<span class="SONG_NGU editable styleChange" style="font-style:italic" data-label="colChietKhau_SN" data-style="colChietKhau_SN">(Discount)</span>
						</th>
					</tr>
					<tr>
						<th>
							<span class="styleChange editable" style="font-weight:bold;" data-label="col1" data-style="col1">1</span>
						</th>
						<th>
							<span class="styleChange editable" style="font-weight:bold;" data-label="col2" data-style="col2"> </span>
						</th>
						<th>
							<span class="styleChange editable" style="font-weight:bold;" data-label="col3" data-style="col3">2</span>
						</th>
						<th>
							<span class="styleChange editable" style="font-weight:bold;" data-label="col4" data-style="col4">3</span>
						</th>
						<th>
							<span class="styleChange editable" style="font-weight:bold;" data-label="col5" data-style="col5">4</span>
						</th>
						<th>
							<span class="styleChange editable" style="font-weight:bold;" data-label="col6" data-style="col6">5</span>
						</th>
						<th>
							<span class="styleChange editable" style="font-weight:bold;" data-label="col7" data-style="col7">6 = 4 x 5</span>
						</th>
						<th>
							<span class="styleChange editable" style="font-weight:bold;" data-label="col8" data-style="col8"> </span>
						</th>
						<th>
							<span class="styleChange editable" style="font-weight:bold;" data-label="col9" data-style="col9"> </span>
						</th>
					</tr>
				</thead>
				<tbody>
					<xsl:for-each select="inv:invoiceData/inv:items/inv:item">
						<xsl:sort select="inv:lineNumber" data-type="number" />
						<tr class="item">
							<xsl:choose>
								<xsl:when test="normalize-space(inv:lineNumber) =''">
									<td class="text-center donghang"> </td>
								</xsl:when>
								<xsl:when test="normalize-space(inv:lineNumber)">
									<td class="text-center donghang">
										<xsl:value-of select="inv:lineNumber" />
									</td>
								</xsl:when>
							</xsl:choose>
							<td class="donghang">
								<xsl:value-of select="inv:itemCode" />
							</td>
							<td class="donghang">
								<xsl:choose>
									<xsl:when test="normalize-space(//inv:adjustmentType) = '5' or normalize-space(//inv:adjustmentType) = '9'">
										<xsl:choose>
											<xsl:when test="normalize-space(inv:isIncreaseItem) = '' or normalize-space(inv:isIncreaseItem) = 'true'">
                      Điều chỉnh tăng:
											</xsl:when>
											<xsl:otherwise>
                      Điều chỉnh giảm:
											</xsl:otherwise>
										</xsl:choose>
									</xsl:when>
								</xsl:choose>
								<xsl:value-of select="inv:itemName" />
								<xsl:choose>
									<xsl:when test="normalize-space(inv:vatPercentage) = '-1' " />
									<xsl:when test="normalize-space(inv:vatPercentage) = '-2' " />
								</xsl:choose>
							</td>
							<td class="text-center donghang">
								<xsl:value-of select="inv:unitName" />
							</td>
							<td class="text-right donghang">
								<xsl:if test="normalize-space(inv:quantity)">
									<xsl:value-of select="format-number(inv:quantity,'##.##0,#####','number')" />
								</xsl:if>
							</td>
							<td class="text-right donghang">
								<xsl:if test="normalize-space(inv:unitPrice)">
									<xsl:value-of select="format-number(inv:unitPrice,'##.##0,######','number')" />
								</xsl:if>
							</td>
							<td class="text-right donghang">
								<xsl:if test="normalize-space(inv:itemTotalAmountWithoutVat)">
									<xsl:value-of select="format-number(inv:itemTotalAmountWithoutVat,'##.##0,#####','number')" />
								</xsl:if>
							</td>
							<td class="text-right donghang">
								<xsl:if test="normalize-space(inv:vatAmount)">
									<xsl:value-of select="format-number(inv:vatAmount,'##.##0,######','number')" />
								</xsl:if>
							</td>
							<td class="text-right donghang">
								<xsl:if test="normalize-space(inv:discount)">
									<xsl:value-of select="format-number(inv:discount,'##.##0,######','number')" />
								</xsl:if>
							</td>
						</tr>
					</xsl:for-each>
					<xsl:variable name="tygia">
						<xsl:choose>
							<xsl:when test="normalize-space(inv:invoiceData/inv:exchangeRate) and normalize-space(inv:invoiceData/inv:exchangeRate) != 1">
							1
							</xsl:when>
							<xsl:otherwise>
							0
							</xsl:otherwise>
						</xsl:choose>
					</xsl:variable>
					<xsl:variable name="chietkhau">
						<xsl:choose>
							<xsl:when test="normalize-space(inv:invoiceData/inv:discountAmount) and inv:invoiceData/inv:discountAmount != 0">
							1
							</xsl:when>
							<xsl:otherwise>
							0
							</xsl:otherwise>
						</xsl:choose>
					</xsl:variable>
					<xsl:variable name="Length" select="55" />
					<xsl:variable name="kct" select="0" />
					<xsl:variable name="kkkt" select="0" />
					<xsl:variable name="tpkhac">
						<xsl:for-each select="inv:invoiceData/inv:items/inv:item">
							<tpkhac>
								<xsl:choose>
									<xsl:when test="normalize-space(inv:vatPercentage) ='-1'">
										<xsl:variable name="ktthua" select="(string-length(inv:itemName) + $kct) mod $Length" />
										<xsl:variable name="ktcan" select="$Length - $ktthua" />
										<xsl:value-of select="((string-length(inv:itemName) - $ktthua + $kct) div $Length) + (($ktthua + $ktcan) div $Length)" />
									</xsl:when>
									<xsl:when test="normalize-space(inv:vatPercentage) ='-2'">
										<xsl:variable name="ktthua" select="(string-length(inv:itemName) + $kkkt) mod $Length" />
										<xsl:variable name="ktcan" select="$Length - $ktthua" />
										<xsl:value-of select="((string-length(inv:itemName) - $ktthua + $kkkt) div $Length) + (($ktthua + $ktcan) div $Length)" />
									</xsl:when>
									<xsl:otherwise>
										<xsl:variable name="ktthua" select="(string-length(inv:itemName) mod $Length)" />
										<xsl:variable name="ktcan" select="$Length - $ktthua" />
										<xsl:value-of select="((string-length(inv:itemName) - $ktthua) div $Length) + (($ktthua + $ktcan) div $Length)" />
									</xsl:otherwise>
								</xsl:choose>
							</tpkhac>
						</xsl:for-each>
					</xsl:variable>
					<xsl:variable name="lenghtNote">
						<xsl:if test="normalize-space(inv:invoiceData/inv:invoiceNote)">
							<Note>
								<xsl:variable name="ktthua1" select="(string-length(inv:invoiceData/inv:invoiceNote) mod $Length)" />
								<xsl:variable name="ktcan1" select="$Length - $ktthua1" />
								<xsl:value-of select="((string-length(inv:invoiceData/inv:invoiceNote) - $ktthua1) div $Length) + (($ktthua1 + $ktcan1) div $Length)" />
							</Note>
						</xsl:if>
					</xsl:variable>
					<xsl:variable name="dong" select="sum(exsl:node-set($tpkhac)/tpkhac)" />
					<xsl:variable name="dongNote" select="sum(exsl:node-set($lenghtNote)/Note)" />
					<xsl:variable name="du" select="10" />
					<xsl:if test="normalize-space(inv:invoiceData/inv:invoiceNote)">
						<tr class="item">
							<td class="donghang text-center" />
							<td class="donghang" />
							<td class="donghang">
								<xsl:value-of select="inv:invoiceData/inv:invoiceNote" />
							</td>
							<td class="donghang" />
							<td class="donghang text-right" />
							<td class="donghang text-right" />
							<td class="donghang text-right" />
							<td class="donghang text-right" />
							<td class="donghang text-right" />
						</tr>
					</xsl:if>
					<xsl:if test="normalize-space(inv:invoiceData/inv:discountAmount) and normalize-space(inv:invoiceData/inv:discountAmount) != 0">
						<tr class="item">
							<td class="donghang text-center" />
							<td class="donghang" />
							<td class="donghang">Chiết khấu: <xsl:if test="number(inv:invoiceData/inv:discountRate)">
									<xsl:value-of select="number(inv:invoiceData/inv:discountRate)" />%</xsl:if>
							</td>
							<td class="donghang" />
							<td class="donghang" />
							<td class="donghang" />
							<td class="donghang text-right">
								<xsl:value-of select="format-number(inv:invoiceData/inv:discountAmount,'##.##0,##','number')" />
							</td>
							<td class="donghang" />
							<td class="donghang" />
						</tr>
					</xsl:if>
					<xsl:call-template name="dummy-rows">
						<xsl:with-param name="how-many" select="$du - $dong - $dongNote - $tygia - $chietkhau" />
					</xsl:call-template>
					<xsl:if test="normalize-space($loaiHoaDon)='01'">
						<tr class="summary">
							<td class="borderTop" colspan="9">
								<div class="col10"> 
									<div class="infoContainer styleChange w95o" data-style="txt_exchangeRateContainer">
										<div class="colLabel" onkeyup="drawDongKe(this)">
											<span class="editable styleChange" data-style="txt_exchangeRate" data-label="txt_exchangeRate">Tỷ giá</span>
											<span class="SONG_NGU editable styleChange" style="font-style:italic;" data-style="txt_exchangeRate_SN" data-label="txt_exchangeRate_SN">(Exchange rate)</span>
										</div>
										<span class="colon">:</span>
										<div class="colVal">
											<xsl:if test="normalize-space(inv:invoiceData/inv:exchangeRate) and normalize-space(inv:invoiceData/inv:exchangeRate) != 1">
												<xsl:value-of select="format-number(inv:invoiceData/inv:exchangeRate,'##.##0,#####','number')" /> VND/<xsl:value-of select="$nguyente" />
											</xsl:if>
											<div class="dottedLineContainer" data-line="exchangeRate_Line">
												<span class="dottedLine styleChange" data-style="exchangeRate_Line" style="top:17.5px;width:0px;left:0px;" />
											</div>
										</div>
									</div>
								</div>
								<div class="col10">
									<div class="infoContainer w99o" data-style="txt_totalContainer">
										<div class="colLabel" onkeyup="drawDongKe(this)">
											<span class="editable styleChange" data-style="txt_total" data-label="txt_total">Cộng tiền hàng</span>
											<span class="SONG_NGU editable styleChange" style="font-style:italic;" data-style="txt_total_SN" data-label="txt_total_SN">(Sub total)</span>
										</div>
										<span class="colon">:</span>
										<div class="colVal text-right">
											<xsl:if test="normalize-space(inv:invoiceData/inv:totalAmountWithoutVAT) != ''">
												<xsl:choose>
													<xsl:when test="normalize-space($nguyente) ='VND'">
														<xsl:value-of select="format-number(inv:invoiceData/inv:totalAmountWithoutVAT,'##.##0,#####','number')" />
													</xsl:when>
													<xsl:otherwise>
														<xsl:value-of select="format-number(inv:invoiceData/inv:totalAmountWithoutVAT,'##,##0.00###')" />
													</xsl:otherwise>
												</xsl:choose>
											</xsl:if>
											<div class="dottedLineContainer" data-line="total_Line">
												<span class="dottedLine styleChange" data-style="total_Line" style="top:17.5px;width:267px;left:92px;" />
											</div>
										</div>
									</div>
								</div>
							</td>
						</tr>
					</xsl:if>
					<xsl:choose>
						<xsl:when test="normalize-space(inv:invoiceData/inv:phatHanh) = 'true'">
							<xsl:if test="normalize-space($loaiHoaDon)='01'">
								<tr class="summary">
									<td class="borderTop" colspan="9">
										<div class="col10">
											<div class="infoContainer w95o" data-style="txt_vatRateContainer">
												<div class="colLabel" onkeyup="drawDongKe(this)">
													<span class="editable styleChange" data-style="txt_vatRate" data-label="txt_vatRate">Thuế suất GTGT</span>
													<span class="SONG_NGU editable styleChange" style="font-style:italic;" data-style="txt_vatRate_SN" data-label="txt_vatRate_SN">(VAT rate)</span>
												</div>
												<span class="colon">:</span>
												<div class="colVal text-center"> %
													<div class="dottedLineContainer" data-line="vatRate_Line">
														<span class="dottedLine styleChange" data-style="vatRate_Line" style="top:17.5px;width:241px;left:103px;" />
													</div>
												</div>
											</div>
										</div>
										<div class="col10 text-right">
											<div class="infoContainer fl w99o" data-style="txt_vatAmountContainer">
												<div class="colLabel" onkeyup="drawDongKe(this)">
													<span class="editable styleChange" data-style="txt_vatAmount" data-label="txt_vatAmount">Tiền thuế GTGT</span>
													<span class="SONG_NGU editable styleChange" style="font-style:italic;" data-style="txt_vatAmount_SN" data-label="txt_vatAmount_SN">(VAT amount)</span>
												</div>
												<span class="colon">:</span>
												<div class="colVal">
													<div class="dottedLineContainer" data-line="vatAmount_Line">
														<span class="dottedLine styleChange" data-style="vatAmount_Line" style="top:17.5px;width:259px;left:100px;" />
													</div>
												</div>
											</div>
										</div>
									</td>
								</tr>
							</xsl:if>
						</xsl:when>
						<xsl:otherwise>
							<xsl:if test="normalize-space($loaiHoaDon)='01'">
								<xsl:for-each select="inv:invoiceData/inv:invoiceTaxBreakdowns/inv:invoiceTaxBreakdown">
									<tr class="summary">
										<td class="borderTop" colspan="9">
											<div class="col10">
												<div class="infoContainer w95o" data-style="txt_vatRateContainer">
													<div class="colLabel" onkeyup="drawDongKe(this)">
														<span class="editable styleChange" data-style="txt_vatRate" data-label="txt_vatRate">Thuế suất GTGT</span>
														<span class="SONG_NGU editable styleChange" style="font-style:italic;" data-style="txt_vatRate_SN" data-label="txt_vatRate_SN">(VAT rate)</span>
													</div>
													<span class="colon">:</span>
													<div class="colVal text-center">
														<xsl:choose>
															<xsl:when test="normalize-space(inv:vatPercentage) = '-1'">
															\</xsl:when>
															<xsl:when test="normalize-space(inv:vatPercentage) = '-2'">
															không kê khai nộp thuế
															</xsl:when>
															<xsl:otherwise>
																<span class="percentage">
																	<xsl:value-of select="inv:vatPercentage" /> %
																</span>
															</xsl:otherwise>
														</xsl:choose>
														<div class="dottedLineContainer" data-line="vatRate_Line">
															<span class="dottedLine styleChange" data-style="vatRate_Line" style="top:17.5px;width:241px;left:103px;" />
														</div>
													</div>
												</div>
											</div>
											<div class="col10 text-right">
												<div class="infoContainer fl w99o" data-style="txt_vatAmountContainer">
													<div class="colLabel" onkeyup="drawDongKe(this)">
														<span class="editable styleChange" data-style="txt_vatAmount" data-label="txt_vatAmount">Tiền thuế GTGT</span>
														<span class="SONG_NGU editable styleChange" data-style="txt_vatAmount_SN" data-label="txt_vatAmount_SN" style="font-style:italic;">(VAT amount)</span>
													</div>
													<span class="colon">:</span>
													<div class="colVal">
														<xsl:choose>
															<xsl:when test="normalize-space(inv:vatPercentage) = '-1'">
																\
															</xsl:when>
															<xsl:when test="normalize-space(inv:vatPercentage) = '0'">
																0
															</xsl:when>
															<xsl:otherwise>
																<xsl:if test="normalize-space(inv:vatTaxAmount) != ''">
																	<xsl:choose>
																		<xsl:when test="normalize-space($nguyente) ='VND'">
																			<xsl:value-of select="format-number(inv:vatTaxAmount,'##.##0','number')" />
																		</xsl:when>
																		<xsl:otherwise>
																			<xsl:value-of select="format-number(inv:vatTaxAmount,'##,##0.00###')" />
																		</xsl:otherwise>
																	</xsl:choose>
																</xsl:if>
															</xsl:otherwise>
														</xsl:choose>
														<div class="dottedLineContainer" data-line="vatAmount_Line">
															<span class="dottedLine styleChange" data-style="vatAmount_Line" style="top:17.5px;width:259px;left:100px;" />
														</div>
													</div>
												</div>
											</div>
										</td>
									</tr>
								</xsl:for-each>
							</xsl:if>
						</xsl:otherwise>
					</xsl:choose>
					<tr class="summary">
						<td class="text-right borderTop" colspan="9">
							<xsl:if test="normalize-space($loaiHoaDon)!='02' and normalize-space($loaiHoaDon) !='07'">
								<div class="col10"> </div>
							</xsl:if>
							<div>
								<xsl:attribute name="class">
									<xsl:if test="normalize-space($loaiHoaDon)!='02' and normalize-space($loaiHoaDon) !='07'">col10</xsl:if>
								</xsl:attribute>
								<div class="infoContainer w99o" data-style="txt_totalPaymentContainer">
									<div class="colLabel" onkeyup="drawDongKe(this)">
										<span class="editable styleChange" data-style="txt_totalPayment" data-label="txt_totalPayment">Tổng tiền thanh toán</span>
										<span class="SONG_NGU editable styleChange" style="font-style:italic;" data-style="txt_totalPayment_SN" data-label="txt_totalPayment_SN">(Total of payment)</span>
									</div>
									<span class="colon">:</span>
									<div class="colVal">
										<xsl:if test="normalize-space(inv:invoiceData/inv:totalAmountWithVAT) != ''">
											<xsl:choose>
												<xsl:when test="normalize-space($nguyente) ='VND'">
													<xsl:value-of select="format-number(inv:invoiceData/inv:totalAmountWithVAT,'##.##0,#####','number')" />
												</xsl:when>
												<xsl:otherwise>
													<xsl:value-of select="format-number(inv:invoiceData/inv:totalAmountWithVAT,'##,##0.00###')" />
												</xsl:otherwise>
											</xsl:choose>
										</xsl:if>
										<div class="dottedLineContainer" data-line="totalPayment_Line">
											<span class="dottedLine styleChange" data-style="totalPayment_Line" style="top:17.5px;width:236px;left:123px;" />
										</div>
									</div>
								</div>
							</div>
						</td>
					</tr>
					<tr class="summary">
						<td class="borderTop" colspan="9">
							<div class="infoContainer" style="width:99.5%" data-style="txt_totalInWordsContainer">
								<div class="colLabel" onkeyup="drawDongKe(this)">
									<span class="editable styleChange" data-style="txt_totalInWords" data-label="txt_totalInWords">Số tiền viết bằng chữ</span>
									<span class="SONG_NGU editable styleChange" style="font-style:italic;" data-style="txt_totalInWords_SN" data-label="txt_totalInWords_SN">(Amount in words)</span>
								</div>
								<span class="colon">:</span>
								<div class="colVal">
									<xsl:attribute name="style">
									min-height:<xsl:value-of select="$lineHeight * 2 + 7" />px;
									</xsl:attribute>
									<span class="readAmountInWords">
										<xsl:value-of select="inv:invoiceData/inv:totalAmountWithVATInWords" />
									</span>
									<div class="dottedLineContainer" data-line="totalInWords_Line">
										<span class="dottedLine styleChange" data-style="totalInWords_Line" style="top:17.5px;width:595px;left:126px;" />
										<span class="dottedLine styleChange" data-style="totalInWords_Line1" style="left:0;top:38.5px;width:100%;" />
										<span class="dottedLine styleChange" data-style="totalInWords_Line2" style="left:0;top:59.5px;width:100%;" />
									</div>
								</div>
							</div>
						</td>
					</tr>
				</tbody>
			</table>
		</div>
	</xsl:template>
	<xsl:template name="TemplateSignature">
		<table id="tblSignature" class="text-center">
			<thead>
				<tr class="signer">
					<th>
						<div class="cot1">Người thực hiện chuyển đổi<p class="br" />
							<i class="SONG_NGU">(Converter)</i>
						</div>
					</th>
					<th>
						<div class="cot2">Người mua hàng<p class="br" />
							<i class="SONG_NGU">(Buyer)</i>
						</div>
					</th>
					<th>
						<div class="cot3">Người bán hàng<p class="br" />
							<i class="SONG_NGU">(Seller)</i>
						</div>
					</th>
					<th>
						<div class="cot4">Thủ trưởng đơn vị<p class="br" />
							<i class="SONG_NGU">(Director)</i>
						</div>
					</th>
				</tr>
			</thead>
			<tbody>
				<tr class="signNote">
					<td>
						<div class="cot1">
							<i>(Ký, ghi rõ họ tên)</i>
							<br />
							<i class="SONG_NGU">(Sign &amp; full name)</i>
						</div>
					</td>
					<td>
						<div class="cot2">
							<i>(Ký, ghi rõ họ tên)</i>
							<br />
							<i class="SONG_NGU">(Sign &amp; full name)</i>
						</div>
					</td>
					<td>
						<div class="cot3">
							<div class="noDirector">
								<i>(Ký, đóng dấu, ghi rõ họ tên)</i>
								<br />
								<i class="SONG_NGU">(Sign, stamp &amp; full name)</i>
							</div>
							<div class="hasDirector">
								<i>(Ký, ghi rõ họ tên)</i>
								<br />
								<i class="SONG_NGU">(Sign &amp; full name)</i>
							</div>
						</div>
					</td>
					<td>
						<div class="cot4">
							<i>(Ký, đóng dấu, ghi rõ họ tên)</i>
							<br />
							<i class="SONG_NGU">(Sign, stamp &amp; full name)</i>
						</div>
					</td>
				</tr>
				<tr class="signature" />
				<tr class="digitalSignature">
					<td class="tdChuyenDoi">
						<div class="cot1">
							<div class="chuyenDoiContainer">
								<xsl:value-of select="inv:viewData/inv:userPrint" />
								<div>Ngày chuyển đổi<i class="SONG_NGU"> (Conversion date)</i>: 
									<xsl:choose>
										<xsl:when test="normalize-space(inv:viewData/inv:DateExchange) != ''">
											<xsl:variable name="dateconvert" select="inv:viewData/inv:DateExchange" />
											<xsl:value-of select="concat(substring($dateconvert, 9, 2),'/', substring($dateconvert, 6, 2),'/', substring($dateconvert, 1, 4))" />
										</xsl:when>
										<xsl:otherwise>
										    /    /20
										</xsl:otherwise>
									</xsl:choose>
								</div>
							</div>
						</div>
					</td>
					<td>
						<div class="cot2"> </div>
					</td>
					<td colspan="2">
						<div id="kysoContainer" class="kysoContainer">
							<xsl:choose>
								<xsl:when test="string(inv:invoiceData/inv:phatHanh)='true'">
									<a href="#" style="text-decoration:none;">
										<div id="kyso" class="kyso">
											<img style="border:none;position: absolute; z-index: -1; right: 30px;top:calc(50% - 19px);" src="data:image/gif;base64,R0lGODlhMgAmAPf/ALLiasrsj7HobtPtsanlUaLeVJ3YVm25MWO0MaznWZvcPuDx0ZHZFfv9+e753X3HIrnsfofQHaLbXrnmcpXbHYvJVrvmebTrbazkUYnKTL/nhPj88vP657Xhebfkca3lc5XaIdfuuqvfYqjeXZLWNJXbG43TMY7WFtzztK/mc7DpYa/mb6rmVIPLLYHKIHrEKnfCK3/JJ33HKIHKJoPMJXXALHzFKYXNJHO/LYbPI3G9LojQIm+7MJDWHozTII3VH4vSIY7WH4nRIZHXHZLYHWq3Mmi1NJPZHJPaHHjDIoLMH/D63/T7537HKP3++3zGKYnRInvFKIPNHYjQI5LZGZDXHKznVs/sp6fiW4nKRpXZJP3+/a/gbN/0vZPPUvT2863db8PojZHYHabjTq7jVfL568DofLTja6HeWdjuvXvDNbnUqY/TM6zmZ5PKbazkca7mcZLZHLvfnq7lbqDcYoLINJHKaJDZELHoc5PXMWi1M4zUFtLvoMnpn4nSGYbPHs3rpcLpg4vUGJbNdO7x7O/4593xx/P75fL57arZevf876nicK/mdqnibojPL+Xz1eX10LHpa6DdSa/oZaLdZNruy6rkTJ/dU9Pqxdvvwcfpl4fIS3K8NH/JInzGJYbKO37BSYjNMpvVVuLy0J7bV9bvr5/ScqLKi7Xfg7HodbbscOz33uH1vrDnb+b02KLbWaXdXXvGJM/qsKfiZYXOG3fDIs/umqjiZef11a7nYI3IXvT77L/ofPj79fn89ub2yH3IHrPjZZjZQsnevIzRN5vZVYTKM3G7RLTamrHpZ6zkb5DXFq/nbJvcMafbZZbZOZ/fRJLVPofONX/IK5XMben12YDJJ/f78/H55bbsb4PMIIHKJYPLKYO/YaHgR4XMLafjRpTXM6PdT6PhSajfWYjKQNXwqNjxq4HLIoLLI7HoceLq3bPpcZHYGZHYGsflqJPaGfv++Ov24Oz34/T67/L56JDTQZHSRa7kVcrqnIrQLozSK4jRGorTGITNHv///yH5BAEAAP8ALAAAAAAyACYAAAj/AP8JHEiwoMGDCBMqXMiwocOHEAv+CuAgosWFrMBZsbTkoseCKAhkU6EKQ8ePHkOqYHCnxAUMTFBaPMciAQMkSOBRuIDvkMyHfBKwWIYTJxUQL2P+XGgrAYFlcY5IldoORDIy5pYmDJBrzDIiYMOCdaelmRmtBwNNGndCzJC3cOFWmdAFbUFekbzt6cG3r98ewewWtCAAmqAgiBMrDjIhIYczACpe9MBOQb8fmDNr/mHBsTgIECSViujEgwAFfnyoXs3ah4aEisgxC5enDZbXDuMBEPCMH5DfwIMDCZPQyYhWUCIoL4BnxAaGDUSoIxEBipDr2LNrUshlxb4/O8LT/xKWqgAkhRtErCBBa0r49/B35FPYYQ4bfzny55diIsUlQAjtAgscJkih34EHXqFQH2hEo8QNEEZ4gzY3zHJLBwZh80oK+jwo4Yc3DLAQGMSgQ8OJKKKYjgukKONMPQOtIsEHjriQ4o0nirgQLqHM4OOPQM6wDTD2MGJACBtkIsEb33QSZJDchOBQNaLEYOWVWMZgzQPSvEHKPcU00sIDWWbZQhoQNYCKDGy26aYMTcQiAx2LUDKNJ0286aYxhlwkSx02BCrooE9EkUQtSUTxxKCMfjLKR4948cKklFZq6aWUlvMoSr4kAsOnoIYq6qgwZOGKVu+oUcOqrLbqaqsZyG5j1wIZ4GDrrbjmausm8wj2zzWm6CDssMQWW0Ehvg4kByc8NOvss81WUEayBFUCygHYZqutLvRQWxAi1BQh7rji2tGLtwchY4QeRrRrhBsNoIsQJscgYO8g8cqL0BendLPGFvoqtM4whARssEABAQA7" kasperskylab_antibanner="on" />
														Signature Valid <br />
														Ký bởi: <xsl:value-of disable-output-escaping="yes" select="inv:invoiceData/inv:sellerLegalName" />
											<br />Ký  <xsl:variable name="signedDate" select="inv:invoiceData/inv:signedDate" />
														ngày:         /         /
										</div>
									</a>
								</xsl:when>
								<xsl:otherwise>
									<xsl:for-each select="hnx:Signature">
										<xsl:if test="@Id = 'seller' and (string(//./inv:viewData/inv:printFlag) != 'true'  or string(//./inv:viewData/inv:printFlag) = 'true' and  string(//./inv:viewData/inv:printFlagViewKySo)='true')">
											<a href="#" style="text-decoration:none;">
												<div id="kyso" class="kyso">
													<img style="border:none;position: absolute; z-index: -1; right: 30px;top:calc(50% - 19px);" src="data:image/gif;base64,R0lGODlhMgAmAPf/ALLiasrsj7HobtPtsanlUaLeVJ3YVm25MWO0MaznWZvcPuDx0ZHZFfv9+e753X3HIrnsfofQHaLbXrnmcpXbHYvJVrvmebTrbazkUYnKTL/nhPj88vP657Xhebfkca3lc5XaIdfuuqvfYqjeXZLWNJXbG43TMY7WFtzztK/mc7DpYa/mb6rmVIPLLYHKIHrEKnfCK3/JJ33HKIHKJoPMJXXALHzFKYXNJHO/LYbPI3G9LojQIm+7MJDWHozTII3VH4vSIY7WH4nRIZHXHZLYHWq3Mmi1NJPZHJPaHHjDIoLMH/D63/T7537HKP3++3zGKYnRInvFKIPNHYjQI5LZGZDXHKznVs/sp6fiW4nKRpXZJP3+/a/gbN/0vZPPUvT2863db8PojZHYHabjTq7jVfL568DofLTja6HeWdjuvXvDNbnUqY/TM6zmZ5PKbazkca7mcZLZHLvfnq7lbqDcYoLINJHKaJDZELHoc5PXMWi1M4zUFtLvoMnpn4nSGYbPHs3rpcLpg4vUGJbNdO7x7O/4593xx/P75fL57arZevf876nicK/mdqnibojPL+Xz1eX10LHpa6DdSa/oZaLdZNruy6rkTJ/dU9Pqxdvvwcfpl4fIS3K8NH/JInzGJYbKO37BSYjNMpvVVuLy0J7bV9bvr5/ScqLKi7Xfg7HodbbscOz33uH1vrDnb+b02KLbWaXdXXvGJM/qsKfiZYXOG3fDIs/umqjiZef11a7nYI3IXvT77L/ofPj79fn89ub2yH3IHrPjZZjZQsnevIzRN5vZVYTKM3G7RLTamrHpZ6zkb5DXFq/nbJvcMafbZZbZOZ/fRJLVPofONX/IK5XMben12YDJJ/f78/H55bbsb4PMIIHKJYPLKYO/YaHgR4XMLafjRpTXM6PdT6PhSajfWYjKQNXwqNjxq4HLIoLLI7HoceLq3bPpcZHYGZHYGsflqJPaGfv++Ov24Oz34/T67/L56JDTQZHSRa7kVcrqnIrQLozSK4jRGorTGITNHv///yH5BAEAAP8ALAAAAAAyACYAAAj/AP8JHEiwoMGDCBMqXMiwocOHEAv+CuAgosWFrMBZsbTkoseCKAhkU6EKQ8ePHkOqYHCnxAUMTFBaPMciAQMkSOBRuIDvkMyHfBKwWIYTJxUQL2P+XGgrAYFlcY5IldoORDIy5pYmDJBrzDIiYMOCdaelmRmtBwNNGndCzJC3cOFWmdAFbUFekbzt6cG3r98ewewWtCAAmqAgiBMrDjIhIYczACpe9MBOQb8fmDNr/mHBsTgIECSViujEgwAFfnyoXs3ah4aEisgxC5enDZbXDuMBEPCMH5DfwIMDCZPQyYhWUCIoL4BnxAaGDUSoIxEBipDr2LNrUshlxb4/O8LT/xKWqgAkhRtErCBBa0r49/B35FPYYQ4bfzny55diIsUlQAjtAgscJkih34EHXqFQH2hEo8QNEEZ4gzY3zHJLBwZh80oK+jwo4Yc3DLAQGMSgQ8OJKKKYjgukKONMPQOtIsEHjriQ4o0nirgQLqHM4OOPQM6wDTD2MGJACBtkIsEb33QSZJDchOBQNaLEYOWVWMZgzQPSvEHKPcU00sIDWWbZQhoQNYCKDGy26aYMTcQiAx2LUDKNJ0286aYxhlwkSx02BCrooE9EkUQtSUTxxKCMfjLKR4948cKklFZq6aWUlvMoSr4kAsOnoIYq6qgwZOGKVu+oUcOqrLbqaqsZyG5j1wIZ4GDrrbjmausm8wj2zzWm6CDssMQWW0Ehvg4kByc8NOvss81WUEayBFUCygHYZqutLvRQWxAi1BQh7rji2tGLtwchY4QeRrRrhBsNoIsQJscgYO8g8cqL0BendLPGFvoqtM4whARssEABAQA7" kasperskylab_antibanner="on"/>
																Signature Valid <br/>
																Ký bởi: <xsl:value-of disable-output-escaping="yes" select="//./inv:invoiceData/inv:sellerLegalName"/>
													<br/>Ký  <xsl:variable name="signedDate" select="//./inv:invoiceData/inv:signedDate"/>
													<xsl:value-of select="concat('ngày: ', substring($signedDate, 9, 2), '/', substring($signedDate, 6, 2), '/', substring($signedDate, 1, 4))"/>
												</div>
											</a>
										</xsl:if>
									</xsl:for-each>
								</xsl:otherwise>
							</xsl:choose>
						</div>
					</td>
				</tr>
			</tbody>
		</table>
	</xsl:template>
	<xsl:template name="TemplateFooterInformation">
		<xsl:variable name="wtc" select="inv:invoiceData/inv:delivery/inv:UrlWebTraCuu" />
		<div class="text-bottom-page">
			<div class="traCuu">
				<xsl:choose>
					<xsl:when test="normalize-space(inv:invoiceData/inv:phatHanh)='true'">
						<span class="styleChange editable" data-style="txt_maNhan" data-label="txt_maNhan">Mã nhận hóa đơn</span>
						<span class="SONG_NGU styleChange editable" data-style="txt_maNhan_SN" data-label="txt_maNhan_SN" style="font-style:italic">(Code for checking)</span>:                
						<span class="styleChange editable pl7" data-style="txt_tracking" data-label="txt_tracking">tra cứu tại</span>
						<span class="SONG_NGU styleChange editable" data-style="txt_tracking_SN" data-label="txt_tracking_SN" style="font-style:italic">(Tracking)</span>:
					</xsl:when>
					<xsl:otherwise>
						<span class="styleChange editable" data-style="txt_maNhan" data-label="txt_maNhan">Mã nhận hóa đơn</span>
						<span class="SONG_NGU styleChange editable" data-style="txt_maNhan_SN" data-label="txt_maNhan_SN" style="font-style:italic">(Code for checking)</span>:
						<b>
							<xsl:if test="inv:invoiceData/inv:delivery/inv:containerNumber = ''">                     </xsl:if>
							<xsl:value-of select="inv:invoiceData/inv:delivery/inv:containerNumber" />
						</b>
						<span class="styleChange editable pl7" data-style="txt_tracking" data-label="txt_tracking">tra cứu tại</span>
						<span class="SONG_NGU styleChange editable" data-style="txt_tracking_SN" data-label="txt_tracking_SN" style="font-style:italic">(Tracking)</span>:
						<a href="{$wtc}">
							<xsl:value-of select="$wtc" />
						</a>
					</xsl:otherwise>
				</xsl:choose>
			</div>
			<div class="note-txtTSBottom">
        (<span class="styleChange editable" data-style="noteInvoiceBot" data-label="noteInvoiceBot" style="font-style:italic">Cần kiểm tra, đối chiếu khi lập, giao nhận hóa đơn</span>
				<span class="SONG_NGU styleChange editable" data-style="noteInvoiceBot_SN" data-label="noteInvoiceBot_SN" style="font-style:italic">/ Need to check and compare when making and delivering invoices</span>)
				<div class="textThaiSonBottom">Xuất bởi phần mềm EInvoice, Công ty TNHH Phát triển công nghệ Thái Sơn  - MST: 0101300842 - www.einvoice.vn</div>
			</div>
		</div>
	</xsl:template>
	<xsl:template name="tableKhoi1">
		<table class="tableKhoi1">
			<tr id="trKhoi1" class="sortable">
				<td data-temp="TemplateLogo" class="">
					<xsl:call-template name="TemplateLogo" />
				</td>
				<td class="infoTemp" data-temp="TemplateSeller">
					<xsl:call-template name="TemplateSeller" />
				</td>
			</tr>
		</table>
	</xsl:template>
	<xsl:template name="tableKhoi2">
		<table class="tableKhoi2">
			<tr id="trKhoi2" class="sortable">
				<td data-temp="emptyTemp" class="">
					<xsl:call-template name="emptyTemp" />
				</td>
				<td class="text-center" data-temp="TemplateInvoiceInformation">
					<xsl:call-template name="TemplateInvoiceInformation" />
				</td>
				<td data-temp="Template_Code_Series_invoiceNumber" class="">
					<xsl:call-template name="Template_Code_Series_invoiceNumber" />
				</td>
			</tr>
		</table>
	</xsl:template>
	<xsl:template name="tableKhoi3">
		<table class="tableKhoi3">
			<tr>
				<td class="infoTemp" data-temp="TemplateBuyer">
					<xsl:call-template name="TemplateBuyer" />
				</td>
			</tr>
			<tr>
				<td>
					<xsl:call-template name="TemplateInvoiceInformation_Change" />
				</td>
			</tr>
		</table>
	</xsl:template>
	<xsl:template name="BangHang_0_PhanTram" match="inv:invoice">
		<xsl:variable name="nguyente" select="inv:invoiceData/inv:currencyCode" />
		<table class="table">
			<thead class="text-center">
				<tr>
					<th style="width:60px;border-left:0">
            Mã vật tư
						<div class="nom SONG_NGU" />
					</th>
					<th>
            Tên vật tư
						<div class="nom SONG_NGU" />
					</th>
					<th style="width:70px">
            ĐVT
						<div class="nom SONG_NGU" />
					</th>
					<th style="width:70px">
            Số lượng
						<div class="nom SONG_NGU" />
					</th>
					<th style="width:100px">
            Đơn giá
						<div class="nom SONG_NGU" />
					</th>
					<th style="width:130px;border-right:0">
            Doanh thu
						<div class="nom SONG_NGU" />
					</th>
				</tr>
			</thead>
			<tbody>
				<xsl:variable name="phathanh" select="inv:invoiceData/inv:phatHanh" />
				<xsl:for-each select="inv:invoiceData/inv:items/inv:item">
					<xsl:sort select="inv:lineNumber" data-type="number" />
					<tr>
						<td>
							<xsl:choose>
								<xsl:when test="normalize-space(inv:itemCode)">
									<xsl:value-of select="inv:itemCode" />
								</xsl:when>
								<xsl:otherwise>
                   
								</xsl:otherwise>
							</xsl:choose>
						</td>
						<td>
							<xsl:choose>
								<xsl:when test="../../inv:adjustmentType = '5' or ../../inv:adjustmentType = '9'">
									<xsl:choose>
										<xsl:when test="inv:isIncreaseItem = '' or inv:isIncreaseItem = 'true'">
                      Điều chỉnh tăng
											<span class="haiCham">: </span>
											<div class="SONG_NGU" />
										</xsl:when>
										<xsl:otherwise>
                      Điều chỉnh giảm
											<span class="haiCham">: </span>
											<div class="SONG_NGU" />
										</xsl:otherwise>
									</xsl:choose>
								</xsl:when>
							</xsl:choose>
							<xsl:value-of select="inv:itemName" />
							<xsl:choose>
								<xsl:when test="inv:vatPercentage = '-1' " />
								<xsl:when test="inv:vatPercentage = '-2' " />
							</xsl:choose>
						</td>
						<td class="text-center">
							<xsl:value-of select="inv:unitName" />
						</td>
						<td class="text-center">
							<xsl:if test="inv:quantity != ''">
								<xsl:value-of select="format-number(inv:quantity,'##.##0','number')" />
							</xsl:if>
						</td>
						<td class="text-right">
							<xsl:if test="normalize-space(inv:unitPrice)">
								<xsl:value-of select="format-number(inv:unitPrice,'##.##0','number')" />
							</xsl:if>
						</td>
						<td class="text-right">
							<xsl:if test="inv:itemTotalAmountWithoutVat != ''">
								<xsl:value-of select="format-number(inv:itemTotalAmountWithoutVat,'##.##0','number')" />
							</xsl:if>
						</td>
					</tr>
				</xsl:for-each>
				<xsl:if test="inv:invoiceData/inv:discountAmount != '' and inv:invoiceData/inv:discountAmount != 0">
					<tr>
						<td class="text-center">
							<xsl:value-of select="count(inv:invoiceData/inv:items/inv:item) + 1" />
						</td>
						<td nowrap="">Chiết khấu</td>
						<td>
							<xsl:choose>
								<xsl:when test="inv:invoiceData/inv:adjustmentType = '5' or inv:invoiceData/inv:adjustmentType = '9'">
									<xsl:choose>
										<xsl:when test="inv:invoiceData/inv:isDiscountAmtPos = 'true'">
                      Điều chỉnh tăng
											<span class="haiCham">: </span>
											<div class="SONG_NGU" />
										</xsl:when>
										<xsl:when test="inv:invoiceData/inv:isDiscountAmtPos = 'false'">
                      Điều chỉnh giảm
											<span class="haiCham">: </span>
											<div class="SONG_NGU" />
										</xsl:when>
									</xsl:choose>
								</xsl:when>
							</xsl:choose>
						</td>
						<td class="text-right" />
						<td class="text-right" />
						<td class="text-right">
							<xsl:value-of select="format-number(inv:invoiceData/inv:discountAmount,'##.##0','number')" />
						</td>
					</tr>
				</xsl:if>
				<tr>
					<td class="text-center" />
					<td class="text-left">
						<b>
              Cộng
							<i class="SONG_NGU" />
						</b>
					</td>
					<td class="text-right" />
					<td class="text-right" />
					<td class="text-right" />
					<td class="text-right">
						<xsl:if test="normalize-space(inv:invoiceData/inv:totalAmountWithVAT) != ''">
							<xsl:value-of select="format-number(inv:invoiceData/inv:totalAmountWithoutVAT,'##.##0','number')" />
						</xsl:if>
					</td>
				</tr>
				<tr>
					<td />
					<td>
						<b>
              Thuế GTGT 0%
							<i class="SONG_NGU" />
              0%
						</b>
					</td>
					<td />
					<td />
					<td />
					<td />
				</tr>
				<tr>
					<td />
					<td>
						<b>
              Cộng
							<i class="SONG_NGU" />
						</b>
					</td>
					<td />
					<td />
					<td />
					<td class="text-right">
						<xsl:if test="normalize-space(inv:invoiceData/inv:totalAmountWithVAT) != ''">
							<xsl:value-of select="format-number(inv:invoiceData/inv:totalAmountWithVAT,'##.##0','number')" />
						</xsl:if>
					</td>
				</tr>
				<tr>
					<td />
					<td>
						<b>
              Tỷ giá
							<i class="SONG_NGU" />
						</b>
					</td>
					<td />
					<td />
					<td />
					<td class="text-right">
						<xsl:if test="normalize-space(inv:invoiceData/inv:exchangeRate) and normalize-space(inv:invoiceData/inv:exchangeRate) !='1'">
							<xsl:value-of select="format-number(inv:invoiceData/inv:exchangeRate,'##.##0,#####','number')" /> VND/<xsl:value-of select="$nguyente" />
						</xsl:if>
					</td>
				</tr>
				<tr>
					<td class="text-center" />
					<td class="text-left">
						<b>
              Tổng cộng VND
							<i class="SONG_NGU" />
						</b>
					</td>
					<td class="text-right">
             
					</td>
					<td class="text-right" />
					<td class="text-right">
             
					</td>
					<td class="text-right">
						<xsl:if test="inv:invoiceData/inv:totalAmountWithVAT != ''">
							<b>
								<xsl:value-of select="format-number(inv:invoiceData/inv:totalAmountWithVAT,'##.##0','number')" />
							</b>
						</xsl:if>
					</td>
				</tr>
			</tbody>
		</table>
	</xsl:template>
	<xsl:template name="BangHang_10_PhanTram" match="inv:invoice">
		<xsl:variable name="nguyente" select="inv:invoiceData/inv:currencyCode" />
		<table class="table">
			<thead class="text-center">
				<tr>
					<th style="width:25px;border-left:0">
            STT
						<div class="SONG_NGU" />
					</th>
					<th style="width:350px">
            Tên vật tư
						<div class="nom SONG_NGU" />
					</th>
					<th style="width:70px">
            ĐVT
						<div class="nom SONG_NGU" />
					</th>
					<th style="width:60px">
            Số lượng
						<div class="nom SONG_NGU" />
					</th>
					<th style="width:90px">
            Đơn giá
						<div class="nom SONG_NGU" />
					</th>
					<th style="width:100px;border-right:0">
            GIÁ TRỊ TRƯỚC THUẾ
						<div class="nom SONG_NGU" />
					</th>
					<th style="width:55px;border-right:0">
            THUẾ SUẤT
						<div class="nom SONG_NGU" />
					</th>
					<th style="width:100px;border-right:0">
            TIỀN THUẾ GTGT
						<div class="nom SONG_NGU" />
					</th>
					<th style="width:110px;border-right:0">
            THÀNH TIỀN
						<div class="nom SONG_NGU" />
					</th>
				</tr>
			</thead>
			<tbody>
				<xsl:variable name="phathanh" select="inv:invoiceData/inv:phatHanh" />
				<xsl:for-each select="inv:invoiceData/inv:items/inv:item">
					<xsl:sort select="inv:lineNumber" data-type="number" />
					<tr>
						<xsl:choose>
							<xsl:when test="inv:lineNumber =''">
								<td class="text-center">
                   
								</td>
							</xsl:when>
							<xsl:when test="inv:lineNumber !=''">
								<td class="text-center">
									<xsl:value-of select="inv:lineNumber" />
								</td>
							</xsl:when>
						</xsl:choose>
						<td>
							<xsl:choose>
								<xsl:when test="../../inv:adjustmentType = '5' or ../../inv:adjustmentType = '9'">
									<xsl:choose>
										<xsl:when test="inv:isIncreaseItem = '' or inv:isIncreaseItem = 'true'">
                      Điều chỉnh tăng: 
										</xsl:when>
										<xsl:otherwise>
                      Điều chỉnh giảm: 
										</xsl:otherwise>
									</xsl:choose>
								</xsl:when>
							</xsl:choose>
							<xsl:value-of select="inv:itemName" />
							<xsl:choose>
								<xsl:when test="inv:vatPercentage = '-1' " />
								<xsl:when test="inv:vatPercentage = '-2' " />
							</xsl:choose>
						</td>
						<td class="text-center">
							<xsl:value-of select="inv:unitName" />
						</td>
						<td class="text-center">
							<xsl:if test="inv:quantity != ''">
								<xsl:value-of select="format-number(inv:quantity,'##.##0','number')" />
							</xsl:if>
						</td>
						<td class="text-right">
							<xsl:if test="normalize-space(inv:unitPrice)">
								<xsl:value-of select="format-number(inv:unitPrice,'##.##0','number')" />
							</xsl:if>
						</td>
						<td class="text-right">
							<xsl:if test="inv:itemTotalAmountWithoutVat != ''">
								<xsl:value-of select="format-number(inv:itemTotalAmountWithoutVat,'##.##0','number')" />
							</xsl:if>
						</td>
						<td class="text-center">
							<xsl:choose>
								<xsl:when test="inv:vatPercentage = '-1'" />
								<xsl:when test="inv:vatPercentage = '-2'" />
								<xsl:otherwise>
									<xsl:if test="inv:vatPercentage != ''">
										<xsl:value-of select="format-number(inv:vatPercentage,'##.##0','number')" />%
									</xsl:if>
								</xsl:otherwise>
							</xsl:choose>
						</td>
						<td class="text-right">
							<xsl:if test="inv:vatAmount != ''">
								<xsl:value-of select="format-number(inv:vatAmount,'##.##0','number')" />
							</xsl:if>
						</td>
						<td class="text-right">
							<xsl:choose>
								<xsl:when test="inv:vatAmount =''">
									<xsl:if test="inv:itemTotalAmountWithoutVat != ''">
										<xsl:value-of select="format-number(inv:itemTotalAmountWithoutVat,'##.##0','number')" />
									</xsl:if>
								</xsl:when>
								<xsl:otherwise>
									<xsl:if test="inv:itemTotalAmountWithoutVat != ''">
										<xsl:value-of select="format-number(inv:itemTotalAmountWithoutVat + inv:vatAmount,'##.##0','number')" />
									</xsl:if>
								</xsl:otherwise>
							</xsl:choose>
						</td>
					</tr>
				</xsl:for-each>
				<xsl:if test="inv:invoiceData/inv:discountAmount != '' and inv:invoiceData/inv:discountAmount != 0">
					<tr>
						<td class="text-center">
							<xsl:value-of select="count(inv:invoiceData/inv:items/inv:item) + 1" />
						</td>
						<td nowrap="">Chiết khấu</td>
						<td>
							<xsl:choose>
								<xsl:when test="inv:invoiceData/inv:adjustmentType = '5' or inv:invoiceData/inv:adjustmentType = '9'">
									<xsl:choose>
										<xsl:when test="inv:invoiceData/inv:isDiscountAmtPos = 'true'">
                      Điều chỉnh tăng
											<span class="haiCham">: </span>
											<div class="SONG_NGU" />
										</xsl:when>
										<xsl:when test="inv:invoiceData/inv:isDiscountAmtPos = 'false'">
                      Điều chỉnh giảm
											<span class="haiCham">: </span>
											<div class="SONG_NGU" />
										</xsl:when>
									</xsl:choose>
								</xsl:when>
							</xsl:choose>
						</td>
						<td class="text-right" />
						<td class="text-right" />
						<td class="text-right">
							<xsl:value-of select="format-number(inv:invoiceData/inv:discountAmount,'##.##0','number')" />
						</td>
					</tr>
				</xsl:if>
				<tr id="tongcong">
					<td colspan="5" class="text-center ">
						<b>
              Cộng
							<i class="SONG_NGU" />
						</b>
					</td>
					<td class="text-right " style="width:77px;border-left:1px solid #000">
						<xsl:if test="inv:invoiceData/inv:totalAmountWithoutVAT != ''">
							<b>
								<xsl:value-of select="format-number(inv:invoiceData/inv:totalAmountWithoutVAT,'##.##0','number')" />
							</b>
						</xsl:if>
					</td>
					<td class="text-right " style="width:48px;border-left:1px solid #000" />
					<td class="text-right " style="width:72px;border-left:1px solid #000">
						<xsl:if test="inv:invoiceData/inv:totalVATAmount != ''">
							<b>
								<xsl:value-of select="format-number(inv:invoiceData/inv:totalVATAmount,'##.##0','number')" />
							</b>
						</xsl:if>
					</td>
					<td class="text-right " style="width:82px;border-left:1px solid #000">
						<xsl:if test="inv:invoiceData/inv:totalAmountWithVAT != ''">
							<b>
								<xsl:value-of select="format-number(inv:invoiceData/inv:totalAmountWithVAT,'##.##0','number')" />
							</b>
						</xsl:if>
					</td>
				</tr>
			</tbody>
		</table>
	</xsl:template>
	<xsl:template name="ChuKy_BangKe" match="inv:invoice">
		<xsl:variable name="issuedDate" select="inv:invoiceData/inv:invoiceIssuedDate" />
		<div class="row">
			<div class="col10">
				<br />
			</div>
			<div class="col10 text-center">
				<br />
        Hà Nội,
				<xsl:choose>
					<xsl:when test="inv:invoiceData/inv:phatHanh='true'">
            Ngày
						<i class="SONG_NGU">(Date)</i>
                
            tháng<i class="SONG_NGU">(month)</i>
                
            năm<i class="SONG_NGU">(year)</i>
					</xsl:when>
					<xsl:otherwise>
            Ngày <i class="SONG_NGU">(Date)</i>
             
						<xsl:value-of select="substring($issuedDate, 9, 2)" /> 
            tháng<i class="SONG_NGU">(month)</i> 
             
						<xsl:value-of select="substring($issuedDate, 6, 2)" /> 
            năm <i class="SONG_NGU">(year)</i>
             
						<xsl:value-of select="substring($issuedDate, 1, 4)" />
					</xsl:otherwise>
				</xsl:choose>
			</div>
		</div>
		<div class="row" style="height:150px">
			<div class="text-left" style="margin-top:3px">
				<div class="col10">
					<p class="text-center">
						<b style="font-size:17px">
              Người lập
							<br />
							<i class="SONG_NGU" />
						</b>
					</p>
				</div>
				<div class="col10">
					<p class="text-center">
						<b style="font-size:17px">
							<b style="font-size:17px">
                Đại diện doanh nghiệp
								<br />
								<i class="SONG_NGU" />
							</b>
						</b>
					</p>
					<br />
					<xsl:choose>
						<xsl:when test="inv:invoiceData/inv:phatHanh='true'">
							<a href="#" style="text-decoration:none;">
								<div id="kyso" class="kyso">
									<img style="border:none;position: absolute; z-index: -1; right: 30px; top:calc(50% - 19px);" src="data:image/gif;base64,R0lGODlhMgAmAPf/ALLiasrsj7HobtPtsanlUaLeVJ3YVm25MWO0MaznWZvcPuDx0ZHZFfv9+e753X3HIrnsfofQHaLbXrnmcpXbHYvJVrvmebTrbazkUYnKTL/nhPj88vP657Xhebfkca3lc5XaIdfuuqvfYqjeXZLWNJXbG43TMY7WFtzztK/mc7DpYa/mb6rmVIPLLYHKIHrEKnfCK3/JJ33HKIHKJoPMJXXALHzFKYXNJHO/LYbPI3G9LojQIm+7MJDWHozTII3VH4vSIY7WH4nRIZHXHZLYHWq3Mmi1NJPZHJPaHHjDIoLMH/D63/T7537HKP3++3zGKYnRInvFKIPNHYjQI5LZGZDXHKznVs/sp6fiW4nKRpXZJP3+/a/gbN/0vZPPUvT2863db8PojZHYHabjTq7jVfL568DofLTja6HeWdjuvXvDNbnUqY/TM6zmZ5PKbazkca7mcZLZHLvfnq7lbqDcYoLINJHKaJDZELHoc5PXMWi1M4zUFtLvoMnpn4nSGYbPHs3rpcLpg4vUGJbNdO7x7O/4593xx/P75fL57arZevf876nicK/mdqnibojPL+Xz1eX10LHpa6DdSa/oZaLdZNruy6rkTJ/dU9Pqxdvvwcfpl4fIS3K8NH/JInzGJYbKO37BSYjNMpvVVuLy0J7bV9bvr5/ScqLKi7Xfg7HodbbscOz33uH1vrDnb+b02KLbWaXdXXvGJM/qsKfiZYXOG3fDIs/umqjiZef11a7nYI3IXvT77L/ofPj79fn89ub2yH3IHrPjZZjZQsnevIzRN5vZVYTKM3G7RLTamrHpZ6zkb5DXFq/nbJvcMafbZZbZOZ/fRJLVPofONX/IK5XMben12YDJJ/f78/H55bbsb4PMIIHKJYPLKYO/YaHgR4XMLafjRpTXM6PdT6PhSajfWYjKQNXwqNjxq4HLIoLLI7HoceLq3bPpcZHYGZHYGsflqJPaGfv++Ov24Oz34/T67/L56JDTQZHSRa7kVcrqnIrQLozSK4jRGorTGITNHv///yH5BAEAAP8ALAAAAAAyACYAAAj/AP8JHEiwoMGDCBMqXMiwocOHEAv+CuAgosWFrMBZsbTkoseCKAhkU6EKQ8ePHkOqYHCnxAUMTFBaPMciAQMkSOBRuIDvkMyHfBKwWIYTJxUQL2P+XGgrAYFlcY5IldoORDIy5pYmDJBrzDIiYMOCdaelmRmtBwNNGndCzJC3cOFWmdAFbUFekbzt6cG3r98ewewWtCAAmqAgiBMrDjIhIYczACpe9MBOQb8fmDNr/mHBsTgIECSViujEgwAFfnyoXs3ah4aEisgxC5enDZbXDuMBEPCMH5DfwIMDCZPQyYhWUCIoL4BnxAaGDUSoIxEBipDr2LNrUshlxb4/O8LT/xKWqgAkhRtErCBBa0r49/B35FPYYQ4bfzny55diIsUlQAjtAgscJkih34EHXqFQH2hEo8QNEEZ4gzY3zHJLBwZh80oK+jwo4Yc3DLAQGMSgQ8OJKKKYjgukKONMPQOtIsEHjriQ4o0nirgQLqHM4OOPQM6wDTD2MGJACBtkIsEb33QSZJDchOBQNaLEYOWVWMZgzQPSvEHKPcU00sIDWWbZQhoQNYCKDGy26aYMTcQiAx2LUDKNJ0286aYxhlwkSx02BCrooE9EkUQtSUTxxKCMfjLKR4948cKklFZq6aWUlvMoSr4kAsOnoIYq6qgwZOGKVu+oUcOqrLbqaqsZyG5j1wIZ4GDrrbjmausm8wj2zzWm6CDssMQWW0Ehvg4kByc8NOvss81WUEayBFUCygHYZqutLvRQWxAi1BQh7rji2tGLtwchY4QeRrRrhBsNoIsQJscgYO8g8cqL0BendLPGFvoqtM4whARssEABAQA7" kasperskylab_antibanner="on" />
                  Signature Valid <br />
                  Ký bởi: <xsl:value-of disable-output-escaping="yes" select="inv:invoiceData/inv:sellerLegalName" />
									<br />Ký  <xsl:variable name="signedDate" select="inv:invoiceData/inv:signedDate" />
                  ngày:         /         /
								</div>
							</a>
						</xsl:when>
						<xsl:otherwise>
							<xsl:for-each select="hnx:Signature">
								<xsl:if test="@Id = 'seller' and string(inv:viewData/inv:printFlagViewKySo)='true'">
									<a href="#" style="text-decoration:none;">
										<div id="kyso" class="kyso">
											<img style="border:none;position: absolute; z-index: -1; right: 30px; top:calc(50% - 19px);" src="data:image/gif;base64,R0lGODlhMgAmAPf/ALLiasrsj7HobtPtsanlUaLeVJ3YVm25MWO0MaznWZvcPuDx0ZHZFfv9+e753X3HIrnsfofQHaLbXrnmcpXbHYvJVrvmebTrbazkUYnKTL/nhPj88vP657Xhebfkca3lc5XaIdfuuqvfYqjeXZLWNJXbG43TMY7WFtzztK/mc7DpYa/mb6rmVIPLLYHKIHrEKnfCK3/JJ33HKIHKJoPMJXXALHzFKYXNJHO/LYbPI3G9LojQIm+7MJDWHozTII3VH4vSIY7WH4nRIZHXHZLYHWq3Mmi1NJPZHJPaHHjDIoLMH/D63/T7537HKP3++3zGKYnRInvFKIPNHYjQI5LZGZDXHKznVs/sp6fiW4nKRpXZJP3+/a/gbN/0vZPPUvT2863db8PojZHYHabjTq7jVfL568DofLTja6HeWdjuvXvDNbnUqY/TM6zmZ5PKbazkca7mcZLZHLvfnq7lbqDcYoLINJHKaJDZELHoc5PXMWi1M4zUFtLvoMnpn4nSGYbPHs3rpcLpg4vUGJbNdO7x7O/4593xx/P75fL57arZevf876nicK/mdqnibojPL+Xz1eX10LHpa6DdSa/oZaLdZNruy6rkTJ/dU9Pqxdvvwcfpl4fIS3K8NH/JInzGJYbKO37BSYjNMpvVVuLy0J7bV9bvr5/ScqLKi7Xfg7HodbbscOz33uH1vrDnb+b02KLbWaXdXXvGJM/qsKfiZYXOG3fDIs/umqjiZef11a7nYI3IXvT77L/ofPj79fn89ub2yH3IHrPjZZjZQsnevIzRN5vZVYTKM3G7RLTamrHpZ6zkb5DXFq/nbJvcMafbZZbZOZ/fRJLVPofONX/IK5XMben12YDJJ/f78/H55bbsb4PMIIHKJYPLKYO/YaHgR4XMLafjRpTXM6PdT6PhSajfWYjKQNXwqNjxq4HLIoLLI7HoceLq3bPpcZHYGZHYGsflqJPaGfv++Ov24Oz34/T67/L56JDTQZHSRa7kVcrqnIrQLozSK4jRGorTGITNHv///yH5BAEAAP8ALAAAAAAyACYAAAj/AP8JHEiwoMGDCBMqXMiwocOHEAv+CuAgosWFrMBZsbTkoseCKAhkU6EKQ8ePHkOqYHCnxAUMTFBaPMciAQMkSOBRuIDvkMyHfBKwWIYTJxUQL2P+XGgrAYFlcY5IldoORDIy5pYmDJBrzDIiYMOCdaelmRmtBwNNGndCzJC3cOFWmdAFbUFekbzt6cG3r98ewewWtCAAmqAgiBMrDjIhIYczACpe9MBOQb8fmDNr/mHBsTgIECSViujEgwAFfnyoXs3ah4aEisgxC5enDZbXDuMBEPCMH5DfwIMDCZPQyYhWUCIoL4BnxAaGDUSoIxEBipDr2LNrUshlxb4/O8LT/xKWqgAkhRtErCBBa0r49/B35FPYYQ4bfzny55diIsUlQAjtAgscJkih34EHXqFQH2hEo8QNEEZ4gzY3zHJLBwZh80oK+jwo4Yc3DLAQGMSgQ8OJKKKYjgukKONMPQOtIsEHjriQ4o0nirgQLqHM4OOPQM6wDTD2MGJACBtkIsEb33QSZJDchOBQNaLEYOWVWMZgzQPSvEHKPcU00sIDWWbZQhoQNYCKDGy26aYMTcQiAx2LUDKNJ0286aYxhlwkSx02BCrooE9EkUQtSUTxxKCMfjLKR4948cKklFZq6aWUlvMoSr4kAsOnoIYq6qgwZOGKVu+oUcOqrLbqaqsZyG5j1wIZ4GDrrbjmausm8wj2zzWm6CDssMQWW0Ehvg4kByc8NOvss81WUEayBFUCygHYZqutLvRQWxAi1BQh7rji2tGLtwchY4QeRrRrhBsNoIsQJscgYO8g8cqL0BendLPGFvoqtM4whARssEABAQA7" kasperskylab_antibanner="on" />
                      Signature Valid <br />
                      Ký bởi: <xsl:value-of select="//./inv:invoiceData/inv:sellerLegalName" />
											<br />Ký  <xsl:variable name="signedDate" select="//./inv:invoiceData/inv:signedDate" />
											<xsl:value-of select="concat('ngày: ', substring($signedDate, 9, 2), '/', substring($signedDate, 6, 2), '/', substring($signedDate, 1, 4))" />
										</div>
									</a>
								</xsl:if>
							</xsl:for-each>
						</xsl:otherwise>
					</xsl:choose>
				</div>
			</div>
		</div>
	</xsl:template>
	<xsl:template name="ThongTinBangKe_BangKe" match="inv:invoice">
		<xsl:variable name="issuedDate" select="inv:invoiceData/inv:invoiceIssuedDate" />
		<div class="text-center">
			<div class="row" style="border-bottom:0;margin-top:7px">
				<div>
					<div class="invName">
            BẢNG KÊ HÀNG HÓA, DỊCH VỤ BÁN LẺ TẠI KHU VỤC CÁCH LY
						<br />
						<i class="SONG_NGU" />
					</div>
					<div class="text-center">
						<xsl:choose>
							<xsl:when test="inv:invoiceData/inv:phatHanh='true'">
                Từ ngày
								<span class="haiCham">: </span>
								<i class="SONG_NGU">(From date)</i>
								Từ ngày<span class="haiCham">: </span>
								<i class="SONG_NGU">(From date)</i>
							</xsl:when>
							<xsl:otherwise>
                Từ ngày
								<span class="haiCham">: </span>
								<i class="SONG_NGU">(From date)</i>
								<xsl:value-of select="concat(' ', substring($issuedDate, 9, 2), ' /', substring($issuedDate, 6, 2), ' / ', substring($issuedDate, 1, 4))" />
                Từ ngày
								<span class="haiCham">: </span>
								<i class="SONG_NGU">(From date)</i>
								<xsl:value-of select="concat(' ', substring($issuedDate, 9, 2), ' /', substring($issuedDate, 6, 2), ' / ', substring($issuedDate, 1, 4))" />
							</xsl:otherwise>
						</xsl:choose>
					</div>
					<div class="text-center">
						<xsl:choose>
							<xsl:when test="inv:invoiceData/inv:phatHanh='true'">
                kèm theo số hóa đơn
								<i class="SONG_NGU" />
                                  
								 Ngày<i class="SONG_NGU" />
							</xsl:when>
							<xsl:otherwise>
                Số
								<i class="SONG_NGU" />
								<xsl:value-of select="inv:invoiceData/inv:SoBangKe" />
                kèm theo số hóa đơn
								<i class="SONG_NGU" />
								<xsl:value-of select="inv:invoiceData/inv:invoiceNumber" />
                 Ngày
								<i class="SONG_NGU" />
								<xsl:value-of select="concat(' ', substring($issuedDate, 9, 2), ' /', substring($issuedDate, 6, 2), ' / ', substring($issuedDate, 1, 4))" />
							</xsl:otherwise>
						</xsl:choose>
					</div>
					<div style="font-size:26px;color:red;padding-top:7px">
						<xsl:value-of select="inv:invoiceData/inv:textBangKe" />
					</div>
				</div>
			</div>
		</div>
	</xsl:template>
	<xsl:template name="ThongTinNguoiMua_BangKe" match="inv:invoice">
		<div class="row">
			<div style="margin-left:5px; margin-top: 10px">
				<div>
					<b>
            Tên đơn vị 
						<span class="haiCham">: </span>
						<i class="SONG_NGU">(Company)</i>
					</b>
				 
					<span class="TitleHD">
						<xsl:value-of disable-output-escaping="yes" select="inv:invoiceData/inv:buyerLegalName" />
					</span>
				</div>
				<div>
					<b>
            Địa chỉ
						<span class="haiCham">: </span>
						<i class="SONG_NGU">(Address):</i>
					</b>
			     
					<xsl:value-of disable-output-escaping="yes" select="inv:invoiceData/inv:buyerAddressLine" />
				</div>
				<div>
					<b>
            Mã số thuế
						<span class="haiCham">: </span>
						<i class="SONG_NGU">(Tax code):</i>
					</b>
			     
					<xsl:value-of select="inv:invoiceData/inv:buyerTaxCode" />
				</div>
				<div>
					<b>
            Điện thoại
						<span class="haiCham">: </span>
						<i class="SONG_NGU">(Tel)</i>
					</b>
				 
					<xsl:value-of select="inv:invoiceData/inv:buyerPhoneNumber" />
				</div>
				<div>
					<b>
            Cửa hàng
						<span class="haiCham">: </span>
						<i class="SONG_NGU" />
					</b>
			     
					<xsl:value-of select="inv:invoiceData/inv:delivery/inv:fromWarehouseName" />
				</div>
			</div>
		</div>
	</xsl:template>
	<xsl:template name="ThongTinThayThe_BangKe" match="inv:invoice">
		<div class="row">
			<xsl:choose>
				<xsl:when test="inv:invoiceData/inv:adjustmentType = '3'">
					<div class="col20" style="padding-bottom:5px">
						<b>
              Thay thế cho hóa đơn điện tử số
							<span class="haiCham">: </span>
							<i class="SONG_NGU" />
						</b>
						<span class="border">
							<xsl:value-of select="inv:invoiceData/inv:originalInvoiceId" />
						</span>
						<br />
					</div>
				</xsl:when>
				<xsl:when test="inv:invoiceData/inv:adjustmentType = '5' and inv:invoiceData/inv:originalInvoiceId != ''">
					<div class="col20" style="padding-bottom:5px">
						<b>
              Điều chỉnh cho hóa đơn điện tử số
							<span class="haiCham">: </span>
							<i class="SONG_NGU" />
						</b>
						<span class="border">
							<xsl:value-of select="inv:invoiceData/inv:originalInvoiceId" />
						</span>
						<br />
					</div>
				</xsl:when>
				<xsl:when test="inv:invoiceData/inv:adjustmentType = '7' and inv:invoiceData/inv:originalInvoiceId != ''">
					<div class="col20" style="padding-bottom:5px">
						<b>
              Xóa bỏ cho hóa đơn điện tử số
							<span class="haiCham">: </span>
							<i class="SONG_NGU" />
						</b>
						<span class="border">
							<xsl:value-of select="inv:invoiceData/inv:originalInvoiceId" />
						</span>
						<br />
					</div>
				</xsl:when>
			</xsl:choose>
		</div>
	</xsl:template>
	<xsl:template name="MauSoKyHieu_BangKe">
		<div>
			<div class="row">
				<div class="col6 text-center">
          Mẫu số
					<span class="haiCham" />
					<i class="SONG_NGU" />
					<b>
						<xsl:value-of select="inv:invoiceData/inv:templateCode" />
					</b>
				</div>
				<div class="col5 text-center">
          Mẫu số
					<span class="haiCham">: </span>
					<i class="SONG_NGU" />
					<b>
						<xsl:value-of select="inv:invoiceData/inv:invoiceSeries" />
					</b>
				</div>
				<div class="col4 text-center">
          Số
					<span class="haiCham">: </span>
					<i class="SONG_NGU" />
					<b>
						<xsl:choose>
							<xsl:when test="inv:invoiceData/inv:phatHanh = 'true'">
                0000000
							</xsl:when>
							<xsl:otherwise>
								<xsl:value-of select="inv:invoiceData/inv:invoiceNumber" />
							</xsl:otherwise>
						</xsl:choose>
					</b>
				</div>
				<div class="col5 text-center">
          Số
					<span class="haiCham">: </span>
					<i class="SONG_NGU" />
					<b>
						<xsl:value-of select="inv:invoiceData/inv:SoBangKe" />
					</b>
				</div>
			</div>
		</div>
	</xsl:template>
	<xsl:template match="inv:invoice">
		<xsl:variable name="printType" select="inv:viewData/inv:printType" />
		<html>
			<head>
				<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
				<xsl:choose>
					<xsl:when test="$printType = 'BK'">
						<title>Bảng kê chi tiết hàng</title>
					</xsl:when>
					<xsl:otherwise>
						<title>Hóa Đơn Điện Tử</title>
					</xsl:otherwise>
				</xsl:choose>
				<meta name="viewport" content="width=device-width, initial-scale=1.0" />
				<meta http-equiv="X-UA-Compatible" content="IE=Edge" />
				<xsl:call-template name="styleHtml" />
				<xsl:call-template name="scriptPage" />
			</head>
			<body id="bodyHoaDon" onload="initDongKe()">
				<xsl:attribute name="version">
					<xsl:value-of select="$version" />
				</xsl:attribute>
				<xsl:attribute name="page-size">
					<xsl:value-of select="$pageSize" />
				</xsl:attribute>
				<xsl:if test="$LoaiTrangHoaDon = 'NHIEU_TRANG'">
					<xsl:attribute name="onload">loadData()</xsl:attribute>
				</xsl:if>
				<xsl:attribute name="class">
					<xsl:value-of select="$vienKe" />  
					<xsl:value-of select="$anhNenVien" />  
					<xsl:value-of select="$songNgu" />  
					<xsl:value-of select="$traCuu" />  
					<xsl:value-of select="$bangTranVien" />  
					<xsl:value-of select="$bangCoVienNgoai" />  
					<xsl:value-of select="$bangBoTronGoc" />  
					<xsl:value-of select="$keNganHeaderBody" />  
					<xsl:value-of select="$keDongBangHang" />  
					<xsl:value-of select="$keCotBangHang" />  
					<xsl:value-of select="$thongTinThangHang" />  
					<xsl:value-of select="$hienAnhLogo" />  
					<xsl:value-of select="$nenLogo" />  
					<xsl:value-of select="$anhNenHoaVan" />  
					<xsl:value-of select="$viTriTextThaiSon" />  
					<xsl:value-of select="$keDongThongTin" />  
					<xsl:value-of select="$phanCachKhoi" />  
					<xsl:value-of select="$LoaiTrangHoaDon" />  
					<xsl:value-of select="$mauHienThi" />  
					<xsl:value-of select="$chuKyThuTruong" />  
					<xsl:value-of select="$bangCoMaHang" />  
					<xsl:value-of select="$bangCoChietKhau" />  
					<xsl:value-of select="$bangCoTienThue" />  
					<xsl:value-of select="$bangCoTyGia" />  
					<xsl:if test="string(inv:viewData/inv:printFlag)='true'">HOA_DON_CHUYEN_DOI</xsl:if>  
				</xsl:attribute>
				<div class="container">
					<xsl:attribute name="style">
						font-family:<xsl:value-of select="$fontFamily" />;
						color:<xsl:value-of select="$fontColor" />;
						line-height:<xsl:value-of select="$lineHeight" />px;
					</xsl:attribute>
					<xsl:attribute name="data-page-size-x">
						<xsl:value-of select="$pageSizeX" />
					</xsl:attribute>
					<xsl:attribute name="data-page-size-y">
						<xsl:value-of select="$pageSizeY" />
					</xsl:attribute>
					<xsl:attribute name="data-border-style">
						<xsl:value-of select="$borderStylePage" />
					</xsl:attribute>
					<xsl:attribute name="data-border-width">
						<xsl:value-of select="$borderWidthPage" />
					</xsl:attribute>
					<xsl:attribute name="data-size-vien-anh">
						<xsl:value-of select="$sizeAnhVien" />
					</xsl:attribute>
					<xsl:attribute name="data-top">
						<xsl:value-of select="$topPage" />
					</xsl:attribute>
					<xsl:attribute name="data-right">
						<xsl:value-of select="$rightPage" />
					</xsl:attribute>
					<xsl:attribute name="data-bottom">
						<xsl:value-of select="$bottomPage" />
					</xsl:attribute>
					<xsl:attribute name="data-left">
						<xsl:value-of select="$leftPage" />
					</xsl:attribute>
					<div id="multi-page" />
					<div id="invoice-data">
						<div class="background">
							<xsl:call-template name="TemplateBackground" />
						</div>
						<div id="headerTemp">
							<table class="w100o">
								<xsl:choose>
									<xsl:when test="$printType = 'BK'">
										<tbody id="invoiceDataBK" class="sortable">
											<tr data-temp="ThongTinBangKe_BangKe">
												<td>
													<xsl:call-template name="ThongTinBangKe_BangKe" />
												</td>
											</tr>
											<tr data-temp="ThongTinNguoiMua_BangKe">
												<td>
													<xsl:call-template name="ThongTinNguoiMua_BangKe" />
												</td>
											</tr>
											<tr data-temp="ThongTinThayThe_BangKe">
												<td>
													<xsl:call-template name="ThongTinThayThe_BangKe" />
												</td>
											</tr>
											<tr data-temp="MauSoKyHieu_BangKe">
												<td>
													<xsl:call-template name="MauSoKyHieu_BangKe" />
												</td>
											</tr>
										</tbody>
									</xsl:when>
									<xsl:otherwise>
										<tbody id="invoiceData" class="sortable">
											<tr data-temp="tableKhoi1" class="">
												<td>
													<xsl:call-template name="tableKhoi1" />
												</td>
											</tr>
											<tr data-temp="tableKhoi2" class="">
												<td>
													<xsl:call-template name="tableKhoi2" />
												</td>
											</tr>
											<tr data-temp="tableKhoi3" class="">
												<td>
													<xsl:call-template name="tableKhoi3" />
												</td>
											</tr>
										</tbody>
									</xsl:otherwise>
								</xsl:choose>
							</table>
						</div>
						<div id="invoiceItems">
							<xsl:choose>
								<xsl:when test="$printType = 'BK'">
									<xsl:choose>
										<xsl:when test="$LoaiThueSuatHoaDon='NHIEU_THUE_SUAT'">
											<xsl:call-template name="BangHang_10_PhanTram" />
										</xsl:when>
										<xsl:otherwise>
											<xsl:call-template name="BangHang_0_PhanTram" />
										</xsl:otherwise>
									</xsl:choose>
								</xsl:when>
								<xsl:otherwise>
									<xsl:call-template name="BangHang" />
								</xsl:otherwise>
							</xsl:choose>
						</div>
						<div id="footerTemp">
							<xsl:choose>
								<xsl:when test="$printType = 'BK'">
									<xsl:call-template name="ChuKy_BangKe" />
								</xsl:when>
								<xsl:otherwise>
									<xsl:call-template name="TemplateSignature" />
									<xsl:call-template name="TemplateFooterInformation" />
								</xsl:otherwise>
							</xsl:choose>
						</div>
					</div>
					<input type="hidden" id="qrcodeContent">
						<xsl:attribute name="value">
							<xsl:value-of select="inv:controlData/inv:qrCodeData" />
						</xsl:attribute>
					</input>
				</div>

			<script><xsl:text disable-output-escaping="yes">
				<![CDATA[
			function createElement(nodeName, className, innerHTML){
					var element = document.createElement(nodeName);
					element.innerHTML = innerHTML;
					element.className = className;
					return element;
			}

			function loadData() {
				var pageContainer = document.getElementsByClassName('container')[0];
				var multiPageContainer = document.getElementById("multi-page");
				//tính maxContentHeight
				var sizeAnhVien = document.getElementsByTagName('body')[0].classList.contains('CO_HINH_ANH_VIEN') ? parseFloat(pageContainer.getAttribute('data-size-vien-anh')) : 0;
				var borderPageW = document.getElementsByTagName('body')[0].classList.contains('CO_VIEN_KE') ? parseFloat(pageContainer.getAttribute('data-border-width')) : 0;
				var lineHeight = parseFloat(window.getComputedStyle(pageContainer,null).getPropertyValue('line-height'));
				var maxContentH = parseFloat(pageContainer.getAttribute('data-page-size-y'))
						- parseFloat(pageContainer.getAttribute('data-top'))
						- parseFloat(pageContainer.getAttribute('data-bottom')) 
						- lineHeight - 2 * sizeAnhVien - 2 * borderPageW;
				// chuẩn bị phân trang
				initDongKe(); 
				var header = document.getElementById("headerTemp");
				var itemList = document.getElementById("invoiceItems").getElementsByClassName("item"); 
				var summaryList = document.getElementById("invoiceItems").getElementsByClassName("summary"); 
	
				var summaryHeight = 0; for(var i = 0; i < summaryList.length; i++) summaryHeight += summaryList[i].offsetHeight;
				var cloneBangHang = createElement('div', 'content', document.getElementById('invoiceItems').innerHTML);
				var tbodyHeight = document.getElementById('invoiceItems').getElementsByTagName('tbody')[0].offsetHeight;
				cloneBangHang.getElementsByTagName('tbody')[0].innerHTML = '';
				var maxRowPerPage = 0; maxColTable = 6; beginPage = 1; currPage = beginPage; endPage = 0;
				var itemCount = (currPage - 1) * maxRowPerPage; 
				var maxTbodyH = maxContentH - header.offsetHeight;

				var pageHTML = "<div class='page-content'>\
							<div class='background'>"+ document.getElementsByClassName("background")[0].innerHTML + "</div>\
							<div class='header'>"+ header.innerHTML + "</div>\
							<div class='content'>"+ cloneBangHang.innerHTML + "</div>\
						</div>\
						<div class='page-number'></div>";
				do{
					// Tạo trang
					var page = createElement('div', 'page', pageHTML);
					multiPageContainer.appendChild(page);
					page.setAttribute('id', 'page' + currPage);
					var currPageContent = page.firstElementChild;	
					var content = currPageContent.lastElementChild;
					var tbody =  content.getElementsByTagName('tbody')[0];
					// add dòng hàng
					if(maxRowPerPage === 0) {
						//Hóa đơn ko quy định số dòng 1 trang
						if(currPage === 1) itemCount --;
						var pageContentH = header.offsetHeight + content.offsetHeight;
						do{
							tbody.appendChild(createElement('tr', itemList[itemCount + 1].className, itemList[itemCount + 1].innerHTML));
							pageContentH += itemList[itemCount + 1].offsetHeight;
							itemCount++;
						} while(itemCount + 1 < itemList.length && pageContentH + itemList[itemCount + 1].offsetHeight < maxContentH);
					} 
					else { 
						//Hóa đơn quy định số dòng 1 trang		
						var beginItem = (currPage - 1) * maxRowPerPage; endItem = currPage * maxRowPerPage < itemList.length ? currPage * maxRowPerPage : itemList.length;
						for(var i = beginItem ; i < endItem; i++){
							tbody.appendChild(createElement('tr', itemList[itemCount].className, itemList[i].innerHTML));
							itemCount++;
						}
					}
					currPage++;
				} while(endPage !== 0 && currPage <= endPage || itemCount + 1 < itemList.length);
				currPage --;
				
				// Thêm footer vào trang cuối
				var footer = document.getElementById("footerTemp");
				var lastPageContent = document.getElementsByClassName('page-content')[currPage - 1];
				var lastContent = lastPageContent.lastElementChild;
				var lastTbody = lastContent.getElementsByTagName('tbody')[0];
				// trường hợp quá khổ 1 trang
				if(lastContent.offsetHeight + header.offsetHeight + summaryHeight + footer.offsetHeight > maxContentH){
					if(currPage === 1 && document.getElementsByClassName('phathanh').length)
						alert('Mẫu phát hành dài quá khổ. Vui lòng chỉnh cỡ chữ hoặc độ dãn dòng bé hơn');
					// Bù dòng trang trước
					var pageContentH = lastContent.offsetHeight + header.offsetHeight;
					do{
						var emptyRowHTML = '<td class="text-center donghang">&#160;</td>\
								<td class="donghang"></td>\
								<td class="donghang"></td>\
								<td class="donghang"></td>\
								<td class="donghang"></td>\
								<td class="donghang"></td>\
								<td class="donghang"></td>\
								<td class="donghang"></td>\
								<td class="donghang"></td>';
						lastTbody.appendChild(createElement('tr', 'item dummy', emptyRowHTML));
						pageContentH += lastTbody.lastElementChild.offsetHeight + 2;
					} while(pageContentH + lastTbody.lastElementChild.offsetHeight < maxContentH);
					// Tạo thêm 1 trang mới
					currPage ++;
					var newPage = createElement('div', 'page', pageHTML);
					multiPageContainer.appendChild(newPage);
					newPage.setAttribute('id', 'page' + currPage);
					var newPageContent = newPage.firstElementChild;	
					lastPageContent = newPageContent;
					lastPageContent.getElementsByClassName('textThaiSonRight')[0].style.bottom = 0;
				} 
				// Thêm các dòng summary vào trang cuối		
				lastContent = lastPageContent.lastElementChild;
				lastTbody	= lastContent.getElementsByTagName('tbody')[0];
				for(var i = 0; i < summaryList.length; i++){
					lastTbody.appendChild(createElement('tr', 'summary', summaryList[i].innerHTML))
				}
				lastPageContent.appendChild(createElement('div','footer', footer.innerHTML));
				if(document.getElementsByClassName('table-vat').length > 0 && lastTbody.childNodes.length == 0)
					lastTbody.parentNode.parentNode.remove();
				if(currPage === 1) {
					textBottom = document.getElementsByClassName('text-bottom-page')[0];
					textBottom.style.position = 'absolute'
					textBottom.style.bottom = sizeAnhVien + 'px'
					lastPageContent.style.position = 'relative'
				} else {
					lastPageContent.style.height = 'auto';
					lastPageContent.style.height = lastPageContent.offsetHeight + sizeAnhVien + 'px';
				}

				// Đánh số trang
				var pageNumbers = document.getElementsByClassName('page-number');
				for(var i = 0; i < pageNumbers.length; i++) {
					if(i == 0)
						pageNumbers[i].textContent = "Trang 1/" + pageNumbers.length;
					else
						pageNumbers[i].textContent = "tiếp theo trang trước - trang " + (i + 1) + "/" + pageNumbers.length;
				}
				// 
				lastPageContent.getElementsByClassName('anhVienHoaDon')[0].style.height = lastPageContent.offsetHeight + 'px';
				document.getElementById('invoice-data').style.display = 'none';
			}

			function drawDongKe(colLabel){
				if(colLabel.getAttribute('onkeyup')) {
					try {
						var currLineHeight = parseFloat(window.getComputedStyle(colLabel,null).getPropertyValue('line-height'));
						var currFontSize = parseFloat(window.getComputedStyle(colLabel,null).getPropertyValue('font-size'));

						var isBenBanThangHang = document.getElementsByTagName('body')[0].classList.contains('BEN_BAN_THANG_HANG');
						var isBenMuaThangHang = document.getElementsByTagName('body')[0].classList.contains('BEN_MUA_THANG_HANG');
						var isRowBenBan = colLabel.parentNode.parentNode.classList.contains('seller');
						var isRowBenMua = colLabel.parentNode.parentNode.classList.contains('buyer');
						
						var dauHaiCham = colLabel.nextElementSibling;
						var colVal = dauHaiCham.nextElementSibling;//colLabel.parentNode.getElementsByClassName('colVal')[0];
						
						var sumWidth = colLabel.parentNode.offsetWidth;
						var sumHeight = colLabel.offsetHeight > colVal.offsetHeight? colLabel.offsetHeight : colVal.offsetHeight;

						// mặc định sumHeight = LineHeight 1 dòng
						if(sumHeight == 0 || sumHeight < currLineHeight) sumHeight = currLineHeight;
						
						var currListDotLine = colVal.getElementsByClassName('dottedLineContainer')[0].children;
						var firstLine = currListDotLine.item(0);
						var lastLine = firstLine.parentNode.lastElementChild;		
						var topOfFirstLine	= currLineHeight/2 + currFontSize/2;				
						var lastLineIndex = currListDotLine.length - 1;
								
						//tự động thêm dòng?
						while(currListDotLine.length *  currLineHeight < sumHeight){	
							var newDotLine = document.createElement("SPAN");
									newDotLine.className = "dottedLine styleChange";
									newDotLine.setAttribute("data-style",  firstLine.getAttribute("data-style") + (lastLineIndex + 1));
									
							insertAfter(lastLine, newDotLine);

							//lấy lại thông tin đã thay đổi
							lastLine = firstLine.parentNode.lastElementChild;
							lastLineIndex++;
						}
						
						// đánh lại left mỗi dòng thông tin
						for(var i = 0; i < currListDotLine.length; i++){
							styleLine = '';
							if(i == 0){
								styleLine += "top:"+ topOfFirstLine +"px;";
								styleLine += "width:"+ (colLabel.offsetWidth === sumWidth ? 0 : (sumWidth -  colLabel.offsetWidth - dauHaiCham.offsetWidth)) + "px;"; 
								styleLine += "left:" + (colLabel.offsetWidth + dauHaiCham.offsetWidth) + "px;";
							} else {
								var topValue = topOfFirstLine + currLineHeight * i;
								styleLine += "left:0;";
								styleLine += "top:" +  topValue + "px;";
								if(isRowBenBan && isBenBanThangHang || isRowBenMua && isBenMuaThangHang || isRowBenMua && isRowBenBan)
									styleLine += "width:" + (sumWidth -  colLabel.offsetWidth - dauHaiCham.offsetWidth) + "px;";
								else styleLine += "width:100%;";
							}
							currListDotLine.item(i).setAttribute('style', styleLine);
						}
						
						// tự động xóa dòng?
						while(lastLine.offsetTop > sumHeight){
							lastLine.parentNode.removeChild(lastLine);
							//cập nhật lại lastLine
							lastLine = firstLine.parentNode.lastElementChild;
						}
					}catch(ex){
						console.log(colLabel);
						console.log(ex);
					}					
				}
			}
			function initDongKe(){
				var colLabel = document.getElementsByClassName('colLabel');
				for(var i = colLabel.length - 1; i >= 0; i--){
					drawDongKe(colLabel[i]);
				}
			}
			function insertAfter(target, newNodeAfter){
				target.parentNode.insertBefore(newNodeAfter, target.nextSibling);
			}
			]]>
			</xsl:text></script></body>
		</html>
	</xsl:template>
	<xsl:template name="dummy-rows">
		<xsl:param name="how-many" select="0" />
		<xsl:if test="$how-many &gt; 0">
			<tr class="item dummy-item">
				<td class="donghang"> </td>
				<td class="donghang" />
				<td class="donghang" />
				<td class="donghang" />
				<td class="donghang" />
				<td class="donghang" />
				<td class="donghang" />
				<td class="donghang" />
				<td class="donghang" />
			</tr>
			<xsl:call-template name="dummy-rows">
				<xsl:with-param name="how-many" select="$how-many - 1" />
			</xsl:call-template>
		</xsl:if>
	</xsl:template>
	<xsl:template match="text()" name="split">
		<xsl:param name="pText" select="inv:itemName" />
		<xsl:if test="string-length($pText)">
			<xsl:if test="($pText =.)">
				<br />
			</xsl:if>
			<xsl:value-of select="substring-before(concat($pText,'::'),'::')" />
			<br />
			<xsl:call-template name="split">
				<xsl:with-param name="pText" select="substring-after($pText, '::')" />
			</xsl:call-template>
		</xsl:if>
	</xsl:template>
	<xsl:template name="emptyTemp">
		<div />
	</xsl:template>
	<xsl:decimal-format name="number" decimal-separator="," grouping-separator="." />
	<xsl:variable name="anhLogo" select="'data:image/png;base64,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'" />
	<xsl:variable name="styleLogo" select="'height: auto; margin: 3px 0px; resize: none; position: relative; zoom: 1; display: block; width: 174.5px; top: 0px; left: 0px;'" />
	<xsl:variable name="hienAnhLogo" select="'CO_HIEN_LOGO'" />
	<xsl:variable name="nenLogo" select="'CO_NEN_LOGO'" />
	<xsl:variable name="anhNenLogo" select="'data:image/png;base64,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'" />
	<xsl:variable name="styleNenLogo" select="'opacity: 0.13; position: absolute; top: 450px; left: 189.5px; width: 350px; height: auto; margin: 0px; resize: none; zoom: 1; display: block;'" />
	<xsl:variable name="anhNenHoaVan" select="'KHONG_NEN_HOA_VAN'" />
	<xsl:variable name="anhHoaVan" select="''" />
	<xsl:variable name="styleNenHoaVan" select="'opacity:0.2;position:absolute;width:690px;top:215px;left:calc(50% - 345px)'" />
	<xsl:variable name="vienKe" select="'CO_VIEN_KE'" />
	<xsl:variable name="styleKeVien" select="''" />
	<xsl:variable name="anhNenVien" select="'KHONG_CO_HINH_ANH_VIEN'" />
	<xsl:variable name="anhVien" select="''" />
	<xsl:variable name="styleAnhVien" select="''" />
	<xsl:variable name="maAnhNenThuVien" select="''" />
	<xsl:variable name="songNgu" select="'KHONG_SONG_NGU'" />
	<xsl:variable name="traCuu" select="'CO_TRA_CUU'" />
	<xsl:variable name="bangTranVien" select="'BANG_CO_TRAN_VIEN'" />
	<xsl:variable name="bangCoVienNgoai" select="'BANG_CO_VIEN_NGOAI'" />
	<xsl:variable name="bangBoTronGoc" select="'BANG_KHONG_BO_TRON_GOC'" />
	<xsl:variable name="keNganHeaderBody" select="''" />
	<xsl:variable name="keDongBangHang" select="'BANG_CO_KE_DONG_MO'" />
	<xsl:variable name="keCotBangHang" select="''" />
	<xsl:variable name="viTriTextThaiSon" select="'TS_BEN_PHAI'" />
	<xsl:variable name="thongTinThangHang" select="'THONG_TIN_KHONG_THANG_HANG'" />
	<xsl:variable name="keDongThongTin" select="''" />
	<xsl:variable name="phanCachKhoi" select="'phanCachKhoi1Khoi2 phanCachKhoi2Khoi3  '" />
	<xsl:variable name="mauHienThi" select="'HOA_DON_GOC'" />
	<xsl:variable name="chuKyThuTruong" select="'CO_CKS_THU_TRUONG'" />
	<xsl:variable name="bangCoMaHang" select="'BANG_KHONG_COT_MA'" />
	<xsl:variable name="bangCoChietKhau" select="'BANG_KHONG_COT_CHIET_KHAU'" />
	<xsl:variable name="bangCoTienThue" select="'BANG_KHONG_COT_TIEN_THUE'" />
	<xsl:variable name="bangCoTyGia" select="'BANG_KHONG_TI_GIA'" />
	<xsl:variable name="fontFamily" select="'&quot;Time New Roman&quot;'" />
	<xsl:variable name="fontSize" select="'14'" />
	<xsl:variable name="lineHeight" select="'21'" />
	<xsl:variable name="fontColor" select="'rgb(0, 0, 0)'" />
	<xsl:variable name="borderStylePage" select="'solid'" />
	<xsl:variable name="borderWidthPage" select="'1'" />
	<xsl:variable name="borderColorPage" select="'rgb(0, 0, 0)'" />
	<xsl:variable name="pageSize" select="'A4'" />
	<xsl:variable name="pageSizeX" select="790" />
	<xsl:variable name="pageSizeY" select="1116" />
	<xsl:variable name="sizeAnhVien" select="20" />
	<xsl:variable name="topPage" select="20" />
	<xsl:variable name="rightPage" select="20" />
	<xsl:variable name="bottomPage" select="20" />
	<xsl:variable name="leftPage" select="20" />
	<xsl:template name="styleHtml">
		<style type="text/css">
		html{
			width:<xsl:value-of select="$pageSizeX - $leftPage - $rightPage" />px;
			<xsl:if test="$LoaiTrangHoaDon = 'MOT_TRANG'">
				padding-top:<xsl:value-of select="$topPage" />px;
				padding-bottom:<xsl:value-of select="$bottomPage" />px;
			</xsl:if>
			padding-right:<xsl:value-of select="$rightPage" />px;
			padding-left:<xsl:value-of select="$leftPage" />px;
			margin:auto!important
		}
		body{margin:0}
		body.CO_HINH_ANH_VIEN{padding:<xsl:value-of select="$sizeAnhVien" />px}
		body.CO_HINH_ANH_VIEN.NHIEU_TRANG{padding: 0 <xsl:value-of select="$sizeAnhVien" />px}
		.background{height:0}
		.container {	
			font-family:<xsl:value-of select="$fontFamily" />;
			color:<xsl:value-of select="$fontColor" />;
			line-height:<xsl:value-of select="$lineHeight" />px;
			font-size:<xsl:value-of select="$fontSize" />px;
			position:relative;padding:0;margin:0
		}
		.CO_HINH_ANH_VIEN.TS_BEN_PHAI .container{width:<xsl:value-of select="$pageSizeX - 2 * $sizeAnhVien - $leftPage - $rightPage - $lineHeight" />px}
		.CO_HINH_ANH_VIEN.TS_BEN_DUOI .container{width:<xsl:value-of select="$pageSizeX - $leftPage - $rightPage - 2 * $sizeAnhVien" />px}
		.KHONG_CO_HINH_ANH_VIEN.TS_BEN_PHAI .container{width:<xsl:value-of select="$pageSizeX - $leftPage - $rightPage - $lineHeight" />px}
		.KHONG_CO_HINH_ANH_VIEN.TS_BEN_DUOI .container{width:<xsl:value-of select="$pageSizeX - $leftPage - $rightPage" />px}
		.MOT_TRANG .container{height:<xsl:value-of select="$pageSizeY - $topPage - $bottomPage" />px}
		.MOT_TRANG.CO_HINH_ANH_VIEN .container{height:<xsl:value-of select="$pageSizeY - 2 * $sizeAnhVien - $topPage - $bottomPage" />px}
		#invoice-data{
			position:relative;height:calc(100% - 2 * <xsl:value-of select="$borderWidthPage" />px);
			border-width:<xsl:value-of select="$borderWidthPage" />px;
			border-style:<xsl:value-of select="$borderStylePage" />;
			border-color:<xsl:value-of select="$borderColorPage" />
		}
		.KHONG_CO_VIEN_KE #invoice-data{width:100%}
		.container table{
			color:<xsl:value-of select="$fontColor" />;
			font-size:<xsl:value-of select="$fontSize" />px;
			line-height:<xsl:value-of select="$lineHeight" />px
		}
		.invoiceNameContainer{margin-bottom:2px}
		.invName{font-size: <xsl:value-of select="$fontSize + 6" />px;line-height:<xsl:value-of select="$fontSize + 6" />px;text-align:center;margin:0;text-transform:uppercase;font-weight:bold}
		.invNameSN{font-size: <xsl:value-of select="$fontSize + 5" />px;line-height:<xsl:value-of select="$fontSize + 5" />px;font-weight:bold}
		.invNameDetail{margin-top:3px;font-style:italic;font-size:<xsl:value-of select="$fontSize" />px;line-height:<xsl:value-of select="$fontSize" />px}
		.invNameDetailSN{font-style:italic;font-size:<xsl:value-of select="$fontSize - 1" />px;line-height:<xsl:value-of select="$fontSize - 1" />px}
		.customInvName{font-size:<xsl:value-of select="$fontSize + 3" />px;line-height:<xsl:value-of select="$fontSize + 3" />px}
		.eivNumber{font-size:<xsl:value-of select="$fontSize + 8" />px;line-height:<xsl:value-of select="$lineHeight + 4" />px;color:red !important}
			<xsl:if test="$fontFamily = 'Calibri'">
			.fixFont{font-family:Roboto,sans-serif,Calibri;font-size:<xsl:value-of select="$fontSize - 2" />px;line-height:<xsl:value-of select="$fontSize - 1" />px}
			.SONG_NGU.fixFont:not(.invNameSN):not(.invNameDetailSN){font-size:<xsl:value-of select="$fontSize - 3" />px;line-height:<xsl:value-of select="$fontSize - 2" />px}
			</xsl:if>
		.maSoThue{font-weight:700;letter-spacing: 4px}
		.tableKhoi1, .tableKhoi2 {border-collapse:collapse}
		.tableKhoi1, .tableKhoi2, .tableKhoi3{width:calc(100% + 4px); margin-left:-2px}
		.tableKhoi3{border-collapse:collapse}


		#anhLogo{margin:3px auto;max-width:<xsl:value-of select="$pageSizeX div 4" />px}
		#anhVienHoaDon{
			height: <xsl:value-of select="$pageSizeY - $topPage - $bottomPage - $lineHeight" />px;
			width:<xsl:value-of select="$pageSizeX - $leftPage - $rightPage" />px;
			left:-<xsl:value-of select="$sizeAnhVien" />px;
			position:absolute;z-index:-4
		}
		#anhVienHoaDon{max-width:<xsl:value-of select="$pageSizeX" />px}
		#anhNenHoaVan, #nenLogo{max-width:<xsl:value-of select="$pageSizeX - $leftPage - $rightPage - 2 * $borderWidthPage" />px}
		.TS_BEN_PHAI #anhNenHoaVan, #nenLogo{max-width:<xsl:value-of select="$pageSizeX - $leftPage - $rightPage - $lineHeight - 2 * $borderWidthPage" />px}
		.MOT_TRANG #anhVienHoaDon{
				height: <xsl:value-of select="$pageSizeY - $topPage - $bottomPage" />px;
				margin-top:-<xsl:value-of select="$sizeAnhVien" />px
		}
		.TS_BEN_PHAI #anhVienHoaDon{width:<xsl:value-of select="$pageSizeX - $leftPage - $rightPage - $lineHeight" />px}
		img[src=""], img:not([src]), .KHONG_HIEN_LOGO #khungDiChuyenLogo, .KHONG_CO_HINH_ANH_VIEN #anhVienHoaDon, .KHONG_NEN_LOGO #khungNenLogo, .KHONG_NEN_HOA_VAN #khungNenHoaVan {display:none}


		.KHONG_CO_VIEN_KE #invoice-data, .KHONG_CO_VIEN_KE .page-content{border:none!important}
		.SONG_NGU{padding-left:3px}
		.SONG_NGU:not(.invNameSN):not(.invNameDetailSN){font-size:<xsl:value-of select="$fontSize - 1" />px}
		.KHONG_SONG_NGU .SONG_NGU{display:none!important}
		.table th{font-weight:normal}
		.table th .SONG_NGU {padding:0}
		.KHONG_SONG_NGU .haiCham {display:inline}
		.CO_SONG_NGU .haiCham{display:none!important}

		.KHONG_TRA_CUU .traCuu{display:none!important;}


		.textThaiSonRight{ 
			font-size:<xsl:value-of select="$fontSize - 1" />px;
			line-height:<xsl:value-of select="$lineHeight - 1" />px;
			right: -<xsl:value-of select="$fontSize - 3" />px;
			margin-top:115%;position:absolute;display:block;font-style:italic;width:0;
		}
		.CO_HINH_ANH_VIEN .textThaiSonRight{right:-<xsl:value-of select="$sizeAnhVien + $fontSize - 3" />px}
		.textThaiSonRight .text{transform:rotate(-90deg);-webkit-transform:rotate(-90deg);white-space:nowrap}
		.textThaiSonBottom{font-style:italic;text-align:center}


		.KE_DONG_BEN_MUA .buyer .dottedLine {border-bottom:1px dotted;position:absolute}
		.KE_DONG_BEN_BAN .seller .dottedLine {border-bottom:1px dotted;position:absolute}
		.KE_DONG_BANG_HANG .table .dottedLine {border-bottom:1px dotted;position:absolute}
		.infoContainer{width:100%;float:left}
		.colLabel{position:relative}
		.colVal{float:none;box-sizing:border-box;position:relative;z-index:-1}

		.khoiThangHang .colLabel{width:170px}	
		.THONG_TIN_KHONG_THANG_HANG .khoiThangHang .colLabel {width:90px}
		.khoiThangHang .colVal, .THONG_TIN_KHONG_THANG_HANG .khoiThangHang .colVal{float:left;width:calc(100% - 100px)}	
		.THONG_TIN_KHONG_THANG_HANG.CO_SONG_NGU .khoiThangHang .colLabel{width:200px}
		.CO_SONG_NGU .khoiThangHang .colLabel{width:200px;}	
		.CO_SONG_NGU .khoiThangHang .colVal{width:calc(100% - 220px)}
		.THONG_TIN_KHONG_THANG_HANG .colLabel{display:inline;float:left}
		.THONG_TIN_KHONG_THANG_HANG .colVal, .THONG_TIN_KHONG_THANG_HANG .seller .colVal, .THONG_TIN_KHONG_THANG_HANG .buyer .colVal{display:block;float:none}
		.THONG_TIN_KHONG_THANG_HANG .colLabel{height:<xsl:value-of select="$lineHeight" />px}


		.BEN_BAN_THANG_HANG .seller .colVal{float:left}
		.BEN_BAN_THANG_HANG .seller .colLabel{width: 160px}
		.BEN_BAN_THANG_HANG .seller .colVal{width: calc(100% - 180px)}
		.BEN_BAN_THANG_HANG.CO_SONG_NGU .seller .colLabel{width: 260px}
		.BEN_BAN_THANG_HANG.CO_SONG_NGU .seller .colVal{width:calc(100% - 280px);float:left}
		.BEN_BAN_THANG_HANG .seller .dottedLine{left:0!important}


		.BEN_BAN_THANG_HANG .seller.khungSmall .colLabel{width:80px}
		.BEN_BAN_THANG_HANG .seller.khungSmall .colVal{width: 100%;float: left}
		.KHONG_SONG_NGU.BEN_BAN_THANG_HANG .seller.khungSmall .colVal{width: calc(100% - 95px)}
		.BEN_BAN_THANG_HANG.CO_SONG_NGU .seller.khungSmall .colLabel{width:145px}
		.BEN_BAN_THANG_HANG.CO_SONG_NGU .seller.khungSmall .colVal{width:calc(100% - 160px)}
		.BEN_BAN_THANG_HANG.CO_SONG_NGU.KE_DONG_BEN_BAN .seller.khungSmall .colVal{width:calc(100% - 155px)}


		.BEN_MUA_THANG_HANG .buyer .colVal{float:left} 
		.BEN_MUA_THANG_HANG .buyer .colLabel{width:160px}
		.BEN_MUA_THANG_HANG .buyer .colVal{width:calc(100% - 180px)}
		.BEN_MUA_THANG_HANG.CO_SONG_NGU .buyer .colLabel{width:222px}
		.BEN_MUA_THANG_HANG.CO_SONG_NGU .buyer .colVal{width:calc(100% - 232px);float:left}
		.BEN_MUA_THANG_HANG .buyer .dottedLine{left:0!important}


		.BEN_MUA_THANG_HANG .buyer.khungSmall .colLabel{width:125px}
		.BEN_MUA_THANG_HANG .buyer.khungSmall .colVal{width:100%;float:left}
		.KHONG_SONG_NGU.BEN_MUA_THANG_HANG .buyer.khungSmall .colVal{width:calc(100% - 135px)}
		.BEN_MUA_THANG_HANG.CO_SONG_NGU .buyer.khungSmall .colLabel{width:145px}
		.BEN_MUA_THANG_HANG.CO_SONG_NGU .buyer.khungSmall .colVal{width:calc(100% - 160px)}
		.BEN_MUA_THANG_HANG.CO_SONG_NGU.KE_DONG_BEN_MUA .buyer.khungSmall .colVal{width:calc(100% - 155px)}

		.dongKhongThangHang .colLabel, .dongKhongThangHang .colVal{width:auto!important}


		.tableContainer{margin:0 auto 10px auto;width:calc(100% - 10px);border:1px solid;border-collapse:collapse}
		.table{width:100%;border-spacing:0;border-collapse:collapse}
		.table tbody tr td.donghang{border-top:1px solid}
		.table thead tr th{border-bottom:1px solid;border-left:1px solid}
		.table tbody tr td{border-bottom:none; border-left:1px solid}
		.table thead tr th:first-child, .table tbody tr td:first-child{border-left:none}
		#headerTemp table td.infoTemp, .header table td.infoTemp{padding:2px 5px 5px 5px}
		.BANG_KHONG_COT_MA .table:not(.table-vat) tr th:nth-child(2), .BANG_KHONG_COT_MA .table:not(.table-vat) tr td:nth-child(2) {display:none}
		.BANG_KHONG_COT_TIEN_THUE .table:not(.table-vat) tr th:nth-child(8), .BANG_KHONG_COT_TIEN_THUE .table:not(.table-vat) tr td:nth-child(8) {display:none}
		.BANG_KHONG_COT_CHIET_KHAU .table:not(.table-vat) tr th:nth-child(9), .BANG_KHONG_COT_CHIET_KHAU .table:not(.table-vat) tr td:nth-child(9) {display:none}
		.BANG_KHONG_TI_GIA [data-style=txt_exchangeRateContainer] {display:none}

		.BANG_CO_TRAN_VIEN .tableContainer{width: 100%}
		.BANG_KHONG_CO_VIEN_NGOAI .tableContainer{border: none}
		.BANG_CO_TRAN_VIEN.CO_VIEN_KE .tableContainer{border-left:none; border-right:none}
		.BANG_CO_BO_TRON_GOC .tableContainer{border-radius:10px}

		.BANG_CO_NGAN_HEADER_BODY_MO .table thead tr th{border-bottom-color: #dddddd}
		.BANG_KHONG_CO_NGAN_HEADER_BODY .table thead tr th{border-bottom: none}

		.BANG_KHONG_CO_KE_COT .table thead tr th, .BANG_KHONG_CO_KE_COT .table tbody tr td{border-left:none}
		.BANG_CO_KE_DONG_MO .table tbody tr td.donghang {border-top: 1px solid #ddd}

		.BANG_KHONG_CO_KE_DONG .table tbody tr td, .table tbody tr:first-child td.donghang {border-top: none}
		.BANG_CO_KE_COT_MO .table thead tr th, .BANG_CO_KE_COT_MO .table tbody tr td{border-left-color:#dddddd}


		.phanCachKhoi1Khoi2 #invoiceData &gt; tr:first-child table{border-bottom: 1px solid}
		.phanCachKhoi2Khoi3 #invoiceData &gt; tr:nth-child(2) table{border-bottom: 1px solid}
		.phanCachKhoi3Khoi4 #invoiceData &gt; tr:nth-child(3) table{border-bottom: 1px solid}

		#headerTemp td, .header td{padding:0}
		[data-temp=Template_Code_Series_invoiceNumber], [data-temp=emptyTemp], [data-temp=TemplateLogo]{width:23%}
		[data-temp=TemplateInvoiceInformation]{padding:5px 0!important}
		.CO_SONG_NGU [data-temp=Template_Code_Series_invoiceNumber], .CO_SONG_NGU [data-temp=emptyTemp], .CO_SONG_NGU [data-temp=TemplateLogo]{width:28%}
		[data-temp=TemplateLogo]{padding:0 5px!important}
		[data-temp=Template_Code_Series_invoiceNumber]{padding-left:5px!important}

		.TS_BEN_DUOI .textThaiSonRight, .TS_BEN_PHAI .textThaiSonBottom{display: none}
		.TS_BEN_DUOI .textThaiSonBottom{display: block}
		.text-bottom-page{
			bottom:<xsl:value-of select="$borderWidthPage" />px;
			line-height: <xsl:value-of select="$lineHeight - 4" />px;
			font-size: <xsl:value-of select="$fontSize - 1" />px;
			width:100%;text-align:center!important
		}
		.MOT_TRANG .text-bottom-page{position:absolute}

		.page{ 
			page-break-inside:avoid;
			page-break-after:always;
			padding-top:<xsl:value-of select="$topPage" />px;
			padding-bottom:<xsl:value-of select="$bottomPage" />px
		}
		.page-number{text-align:right}
		.CO_HINH_ANH_VIEN .page-number{margin-right:-<xsl:value-of select="$sizeAnhVien" />px}
		.page-content{height:<xsl:value-of select="$pageSizeY - $topPage - $bottomPage - $lineHeight" />px}
		.CO_VIEN_KE .page-content{
			height:calc(<xsl:value-of select="$pageSizeY - $topPage - $bottomPage - $lineHeight" />px - 2 * <xsl:value-of select="$borderWidthPage" />px);
			border-width:<xsl:value-of select="$borderWidthPage" />px;
			border-style:<xsl:value-of select="$borderStylePage" />;
			border-color:<xsl:value-of select="$borderColorPage" />
		}
		.CO_HINH_ANH_VIEN .header{padding-top:<xsl:value-of select="$sizeAnhVien" />px}

		.clearBoth{clear:both}
		.centerContainer{display:flex;justify-content:center;align-items:center}
		.w02o{width:2%}
		.w05o{width:5%}
		.w10o{width:10%}
		.w15o{width:15%}
		.w20o{width:20%}
		.w23o{width:23%}
		.w25o{width:25%}
		.w27o{width:27%}
		.w30o{width:30%}
		.w35o{width:35%}
		.w40o{width:40%}
		.w43o{width:43%}
		.w45o{width:45%}
		.w50o{width:50%}
		.w55o{width:55%}
		.w60o{width:60%}
		.w65o{width:65%}
		.w70o{width:70%}
		.w75o{width:75%}
		.w80o{width:80%}
		.w85o{width:85%}
		.w90o{width:90%}
		.w95o{width:95%}
		.w99o{width:99%}
		.w100o{width:100%}

		.col1  {width: 5%}
		.col2  {width: 10%}
		.col3  {width: 15%}
		.col4  {width: 20%}
		.col5  {width: 25%}
		.col6  {width: 30%}
		.col7  {width: 35%}
		.col8  {width: 40%}
		.col9  {width: 45%}
		.col10 {width: 50%}
		.col11 {width: 55%}
		.col12 {width: 60%}
		.col13 {width: 65%}
		.col14 {width: 70%}
		.col15 {width: 75%}
		.col16 {width: 80%}
		.col17 {width: 85%}
		.col18 {width: 90%}
		.col19 {width: 95%}
		.col20 {width: 100%}

		.dbl{display:block!important}
		.dib{display:inline-block}
		.fl{float:left!important} .fr{float:right!important}
		.ml5{margin-left:5px} .mr5{margin-right:5px} .pl5{padding-left:5px} .pr5{padding-right:5px} .pl7{padding-left:7px} .pr7{padding-right:7px} .pr3{padding-right:5px} .pd0{padding:0}
		[class*=col]:not(.colVal){float:left}
		.text-left{text-align:left!important}
		.text-right{text-align:right!important}
		.text-center{text-align:center!important}
		.colon{padding-right:3px}
		.text-center .colon{float:none}
		p{margin:0 0 5px}
		.text-left{text-align:left !important}
		.text-right{text-align:right !important}
		.text-center{text-align:center !important}
		.borderTop{border-top: 1px solid !important}
		.borderLeft{border-left: 1px solid !important}
		.borderRight{border-right: 1px solid !important}
		.borderBot{border-bottom: 1px solid !important}
		.borderAll{border: 1px solid !important}
		.phathanh{position: absolute;top: 500px;left:calc(50% - 125px);width: 250px;height: auto;background:none;transform:rotate(-45deg);-webkit-transform:rotate(-45deg);opacity:0.8}
		.xoabo{font-size:20px;color:red;text-transform:uppercase;font-weight: 700}


		.printFlag{margin-top:3px;line-height:<xsl:value-of select="$lineHeight - 2" />px;font-size:<xsl:value-of select="$fontSize - 1" />px}
		.printFlag .SONG_NGU{font-size:<xsl:value-of select="$fontSize - 2" />px!important}
		.HOA_DON_GOC .hoaDonChuyenDoi {display:none}
		#tblSignature{width:100%;line-height:<xsl:value-of select="$lineHeight - 4" />px}
		#tblSignature .signature{height:25px}

		#tblSignature .hasDirector{display:none}
		#tblSignature .br{display:none}
		#kyso{ 
			line-height:<xsl:value-of select="$fontSize - 2" />px;
			font-size:<xsl:value-of select="$fontSize - 5" />px;
			max-width:<xsl:value-of select="$pageSizeX div 3" />px;
			margin:0 auto;border:solid 1px red;padding:3px;color:red;position:relative;z-index:1;text-align:left
		}
			<xsl:if test="$fontFamily = 'Calibri'">#kyso{font-size:<xsl:value-of select="$fontSize - 4" />px;}</xsl:if>
		#tblSignature .cot1, #tblSignature .cot4{display:none}
		#tblSignature th:nth-child(2){width:50%}
		#tblSignature .tdChuyenDoi{vertical-align:bottom}
		#tblSignature .tdChuyenDoi .cot1{position:relative;min-height:<xsl:value-of select="($lineHeight - 2) * 3 + 8" />px}
		#tblSignature .chuyenDoiContainer{position: absolute;width: 350px;left: 0;text-align: left;bottom:0}
		.CO_CKS_THU_TRUONG #tblSignature .cot4{display:block}
		.CO_CKS_THU_TRUONG #tblSignature th:nth-child(2), .CO_CKS_THU_TRUONG #tblSignature th:nth-child(3), .CO_CKS_THU_TRUONG #tblSignature th:nth-child(4){width:33%}


		.HOA_DON_CHUYEN_DOI .hoaDonChuyenDoi {display:block}
		.HOA_DON_CHUYEN_DOI #tblSignature th:nth-child(1), .HOA_DON_CHUYEN_DOI #tblSignature th:nth-child(2){width:33.3%}
		.HOA_DON_CHUYEN_DOI.CO_SONG_NGU #tblSignature th:nth-child(1){width:40%}
		.HOA_DON_CHUYEN_DOI.CO_SONG_NGU #tblSignature th:nth-child(2){width:25%}
		.HOA_DON_CHUYEN_DOI .hoaDonGoc {display:none;}
		.HOA_DON_CHUYEN_DOI #tblSignature .cot1{display:block}
		.HOA_DON_CHUYEN_DOI.CO_CKS_THU_TRUONG #tblSignature th:nth-child(1), .HOA_DON_CHUYEN_DOI.CO_CKS_THU_TRUONG #tblSignature th:nth-child(4){width:28%}
		.HOA_DON_CHUYEN_DOI.CO_CKS_THU_TRUONG #tblSignature th:nth-child(2), .HOA_DON_CHUYEN_DOI.CO_CKS_THU_TRUONG #tblSignature th:nth-child(3){width:22%}
		.CO_CKS_THU_TRUONG #tblSignature .hasDirector{display:block}
		.CO_CKS_THU_TRUONG #tblSignature .noDirector{display:none}
		.CO_CKS_THU_TRUONG.HOA_DON_CHUYEN_DOI.CO_SONG_NGU #tblSignature .br {display:block}
		.CO_CKS_THU_TRUONG #tblSignature #kysoContainer{float:right}

		.HOA_DON_CHUYEN_DOI.AN_CHU_KY_SO #kysoContainer {display:none}

		.readAmountInWords{font-weight:bold;font-size:<xsl:value-of select="$fontSize + 1" />px}
		[page-size="A5"] #kyso{font-size:<xsl:value-of select="$fontSize - 4" />px}
		[page-size="A5"] [data-temp=Template_Code_Series_invoiceNumber], [page-size="A5"] [data-temp=emptyTemp], [page-size="A5"] [data-temp=TemplateLogo]{width:25%}
		.CO_SONG_NGU[page-size="A5"] [data-temp=Template_Code_Series_invoiceNumber], .CO_SONG_NGU[page-size="A5"] [data-temp=emptyTemp], .CO_SONG_NGU[page-size="A5"] [data-temp=TemplateLogo]{width:30%}
		[page-size="A5"] .tableKhoi3{margin-bottom:0}
		.BEN_MUA_THANG_HANG[page-size="A5"] .buyer .colLabel, .BEN_BAN_THANG_HANG[page-size="A5"] .seller .colLabel{width:95px}
		.BEN_MUA_THANG_HANG[page-size="A5"] .buyer .colVal, .BEN_BAN_THANG_HANG[page-size="A5"] .seller .colVal{width: calc(100% - 105px)}
		.BEN_MUA_THANG_HANG.CO_SONG_NGU[page-size="A5"] .buyer .colLabel{width:175px}
		.BEN_MUA_THANG_HANG.CO_SONG_NGU[page-size="A5"] .buyer .colVal{width:calc(100% - 185px)}
		.BEN_BAN_THANG_HANG.CO_SONG_NGU[page-size="A5"] .seller .colLabel{width:110px}
		.BEN_BAN_THANG_HANG.CO_SONG_NGU[page-size="A5"] .seller .colVal{width:calc(100% - 120px)}
		</style>
		<style />
	</xsl:template>
</xsl:stylesheet>