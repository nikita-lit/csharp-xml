<?xml version="1.0" encoding="UTF-8"?>

<xsl:stylesheet version="1.0"
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
    
    <xsl:output method="html" encoding="UTF-8"/>

    <xsl:template match="/">

        <html>
            <head>
                <link rel="stylesheet" href="/css/site.css"/>
            </head>
            <body>
                
                <table border="1" class="reis-table">
                    <tr>
                        <th>Nimetus</th>
                        <th>Riik</th>
                        <th>Pikkus</th>
                        <th>Reisihind</th>
                        <th>Transport</th>
                    </tr>
                    <xsl:for-each select="reisid/reis/suund">
                        <xsl:sort select="pikkus" order="descending"/>
                        <tr>
                            <td><xsl:value-of select="nimetus"/></td>
                            <td><xsl:value-of select="riik"/></td>
                            <td><xsl:value-of select="pikkus"/></td>
                            <td><xsl:value-of select="reisihind"/></td>
                            <td><xsl:value-of select="transport"/></td>
                        </tr>
                    </xsl:for-each>
                </table>

                <br/>

                <strong>Kõik suunad:</strong>

                <h1>
                    <xsl:for-each select="reisid/reis/suund">
                        <xsl:value-of select="riik"/>
                        <br/>
                    </xsl:for-each>
                </h1>

                <ul>
                    <xsl:for-each select="reisid/reis/suund">
                        <li style="background-color: yellow;">
                            <xsl:value-of
                                    select="concat(riik, ' ', pikkus, ' päeva, ', nimetus)"/>
                        </li>
                    </xsl:for-each>
                </ul>

                <ul>
                    <xsl:for-each select="reisid/reis/suund">
                        <li>
                            <xsl:value-of select="concat(riik, ' ', pikkus, ' päeva, ', nimetus)"/>

                            <xsl:if test="pikkus &gt; 4">
                                <strong> - Pikk reis</strong>
                            </xsl:if>
                        </li>
                    </xsl:for-each>
                </ul>

                <br/>
                <strong>Kogumaksumus</strong>
                <br/>
                <xsl:value-of select="concat('summa: ', sum(reisid/reis/suund/reisihind), ' Eurot')"/>

                <br/>
                <strong>Transport</strong>
                <br/>
                <ul>
                    <xsl:for-each select="reisid/reis/suund">
                        <xsl:if test="transport = 'Lennureis'">
                            <li>
                                <xsl:value-of select="concat(nimetus, ', ', riik, ', ', 'Transport: ', transport)"/>
                            </li>
                        </xsl:if>
                    </xsl:for-each>
                </ul>

                <br/>
                <strong>Sorteeri reisid kestvuse järgi</strong>
                <br/>

                <ul>
                <xsl:for-each select="reisid/reis/suund">
                    <xsl:sort select="pikkus" order="descending"/>
                    <li>
                        <xsl:value-of select="concat(nimetus, ', ', riik, ', ', 'Pikkus: ', pikkus)"/>
                    </li>
                </xsl:for-each>
                </ul>

            </body>
        </html>

    </xsl:template>

</xsl:stylesheet>