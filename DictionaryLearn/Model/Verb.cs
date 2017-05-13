using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace DictionaryLearn.Model
{
    //-------------------------------------------------------------------------------------------------------------------
    // class Verb
    //-------------------------------------------------------------------------------------------------------------------
    class Verb
    {
        public string Infinitive { get; set; }
        public string PastSimple { get; set; }
        public string ParticipleII { get; set; }
        public string Translation { get; set; }
        //-------------------------------------------------------------------------------------------------------------------
        static public List<Verb> CreateFromHTML()
        {
            List<Verb> lVerbs = new List<Verb>();
//            string pattern = @"<tr>\s*<td>([^<>]+)</td>\s*<td>([^<>]+)</td>\s*<td>([^<>]+)</td>\s*<td>([^<>]+)</td>\s*<td>([^<>]+)</td>.*</tr>";
            string pattern = @"<tr>\s*<td>([^<>]+)</td>\s*<td>([^<>]+)</td>\s*<td>([^<>]+)</td>\s*<td>([^<>]+)</td>\s*</tr>";
            //            Match match = Regex.Match(stringHTML, pattern);
            foreach (Match match in Regex.Matches(stringHTML, pattern))
            {

                Verb v = new Verb() { Infinitive = match.Groups[1].Value,PastSimple = match.Groups[2].Value,
                                      ParticipleII = match.Groups[3].Value
                                      ,
                                      Translation = match.Groups[4].Value
                };
                lVerbs.Add(v);
                //if (lVerbs.Count > 9)
                //    break;
            }
            return lVerbs;
        }
        //-------------------------------------------------------------------------------------------------------------------
        public static void SaveDictionary(List<Verb> pDictionary)
        {
            XDocument docDictionary = CreateXMLFromDictionary(pDictionary);
            docDictionary.Save("Dictionary.xml");
        }
        //-------------------------------------------------------------------------------------------------------------------
        public static XDocument CreateXMLFromDictionary(List<Verb> pDictionary)
        {
            XDocument d = new XDocument(
                new XElement("Dictionary",
                    from w in pDictionary
                    select new XElement("Word",
                        new XElement("Native", w.Infinitive),
                        new XElement("Translation", w.Translation)))
            );
            return d;
        }
        //-------------------------------------------------------------------------------------------------------------------
        static private string stringHTML = @"<table border=""1px"" width=""980"" cellpadding=""5"" cellspacing=""3"">
    <tr>
        <th>infinitive</th>
        <th>past simple</th>
        <th>past participle</th>
        <th>перевод</th>
    </tr>
    <tr>
    </tr>
    <tr>
        <td>beat</td>
        <td>beat</td>
        <td>beaten</td>
        <td>бить, колотить</td>
    </tr>
    <tr>
        <td>become</td>
        <td>became</td>
        <td>become</td>
        <td>становиться</td>
    </tr>
    <tr>
        <td>begin</td>
        <td>began</td>
        <td>begun</td>
        <td>начинать</td>
    </tr>
    <tr>
        <td>bend</td>
        <td>bent</td>
        <td>bent</td>
        <td>сгибать, гнуть, изгибать</td>
    </tr>
    <tr>
        <td>bet</td>
        <td>bet</td>
        <td>bet</td>
        <td>спорить, держать пари</td>
    </tr>
    <tr>
        <td>bite</td>
        <td>bit</td>
        <td>bitten</td>
        <td>кусать</td>
    </tr>
    <tr>
        <td>blow</td>
        <td>blew</td>
        <td>blown</td>
        <td>дуть, выдыхать</td>
    </tr>
    <tr>
        <td>break</td>
        <td>broke</td>
        <td>broken</td>
        <td>ломать, разбивать, разрушать</td>
    </tr>
    <tr>
        <td>bring</td>
        <td>brought</td>
        <td>brought</td>
        <td>приносить, привозить, доставлять</td>
    </tr>
    <tr>
        <td>broadcast</td>
        <td>broadcast</td>
        <td>broadcast</td>
        <td>вещать, передавать по радио</td>
    </tr>
    <tr>
        <td>build</td>
        <td>built</td>
        <td>built</td>
        <td>строить, сооружать</td>
    </tr>
    <tr>
        <td>burst</td>
        <td>burst</td>
        <td>burst</td>
        <td>лопаться, разрываться</td>
    </tr>
    <tr>
        <td>buy</td>
        <td>bought</td>
        <td>bought</td>
        <td>купить, покупать, приобретать</td>
    </tr>
    <tr>
        <td>catch</td>
        <td>caught</td>
        <td>caught</td>
        <td>ловить, поймать, схватить</td>
    </tr>
    <tr>
        <td>choose</td>
        <td>chose</td>
        <td>chosen</td>
        <td>выбирать, избирать</td>
    </tr>
    <tr>
        <td>come</td>
        <td>came</td>
        <td>come</td>
        <td>приходить, подходить</td>
    </tr>
    <tr>
        <td>cost</td>
        <td>cost</td>
        <td>cost</td>
        <td>стоить, обходиться</td>
    </tr>
    <tr>
        <td>creep</td>
        <td>crept</td>
        <td>crept</td>
        <td>ползать, пресмыкаться</td>
    </tr>
    <tr>
        <td>cut</td>
        <td>cut</td>
        <td>cut</td>
        <td>резать, разрезать</td>
    </tr>
    <tr>
        <td>deal</td>
        <td>dealt</td>
        <td>dealt</td>
        <td>иметь дело, распределять, поступать</td>
    </tr>
    <tr>
        <td>dig</td>
        <td>dug</td>
        <td>dug</td>
        <td>копать, рыть</td>
    </tr>
    <tr>
        <td>do</td>
        <td>did</td>
        <td>done</td>
        <td>делать, выполнять</td>
    </tr>
    <tr>
        <td>draw</td>
        <td>drew</td>
        <td>drawn</td>
        <td>рисовать, чертить</td>
    </tr>
    <tr>
        <td>drink</td>
        <td>drank</td>
        <td>drunk</td>
        <td>пить</td>
    </tr>
    <tr>
        <td>drive</td>
        <td>drove</td>
        <td>driven</td>
        <td>ездить, подвозить, водить (авто)</td>
    </tr>
    <tr>
        <td>eat</td>
        <td>ate</td>
        <td>eaten</td>
        <td>есть, поглощать, поедать</td>
    </tr>
    <tr>
        <td>fall</td>
        <td>fell</td>
        <td>fallen</td>
        <td>падать</td>
    </tr>
    <tr>
        <td>feed</td>
        <td>fed</td>
        <td>fed</td>
        <td>кормить</td>
    </tr>
    <tr>
        <td>feel</td>
        <td>felt</td>
        <td>felt</td>
        <td>чувствовать, ощущать</td>
    </tr>
    <tr>
        <td>fight</td>
        <td>fought</td>
        <td>fought</td>
        <td>драться, сражаться, воевать</td>
    </tr>
    <tr>
        <td>find</td>
        <td>found</td>
        <td>found</td>
        <td>находить, обнаруживать, заставать</td>
    </tr>
    <tr>
        <td>flee</td>
        <td>fled</td>
        <td>fled</td>
        <td>убегать, спасаться бегством, исчезать</td>
    </tr>
    <tr>
        <td>fly</td>
        <td>flew</td>
        <td>flown</td>
        <td>летать</td>
    </tr>
    <tr>
        <td>forbid</td>
        <td>forbad</td>
        <td>forbidden</td>
        <td>запрещать, не позволять, препятствовать</td>
    </tr>
    <tr>
        <td>forget</td>
        <td>forgot</td>
        <td>forgotten</td>
        <td>забывать о (чём-либо)</td>
    </tr>
    <tr>
        <td>forgive</td>
        <td>forgave</td>
        <td>forgiven</td>
        <td>прощать</td>
    </tr>
    <tr>
        <td>freeze</td>
        <td>froze</td>
        <td>frozen</td>
        <td>замораживать, сковывать, морозить</td>
    </tr>
    <tr>
        <td>get</td>
        <td>got</td>
        <td>got</td>
        <td>получать, добираться</td>
    </tr>
    <tr>
        <td>give</td>
        <td>gave</td>
        <td>given</td>
        <td>дать, подать, дарить</td>
    </tr>
    <tr>
        <td>go</td>
        <td>went</td>
        <td>gone</td>
        <td>идти, двигаться</td>
    </tr>
    <tr>
        <td>grow</td>
        <td>grew</td>
        <td>grown</td>
        <td>расти, вырастать</td>
    </tr>
    <tr>
        <td>hang</td>
        <td>hung</td>
        <td>hung</td>
        <td>вешать, развешивать, висеть</td>
    </tr>
    <tr>
        <td>have</td>
        <td>had</td>
        <td>had</td>
        <td>иметь, обладать</td>
    </tr>
    <tr>
        <td>hear</td>
        <td>heard</td>
        <td>heard</td>
        <td>слышать, услышать</td>
    </tr>
    <tr>
        <td>hide</td>
        <td>hid</td>
        <td>hidden</td>
        <td>прятать, скрывать</td>
    </tr>
    <tr>
        <td>hit</td>
        <td>hit</td>
        <td>hit</td>
        <td>ударять, поражать</td>
    </tr>
    <tr>
        <td>hold</td>
        <td>held</td>
        <td>held</td>
        <td>держать, удерживать, задерживать</td>
    </tr>
    <tr>
        <td>hurt</td>
        <td>hurt</td>
        <td>hurt</td>
        <td>ранить, причинять боль, ушибить</td>
    </tr>
    <tr>
        <td>keep</td>
        <td>kept</td>
        <td>kept</td>
        <td>хранить, сохранять, поддерживать</td>
    </tr>
    <tr>
        <td>kneel</td>
        <td>knelt</td>
        <td>knelt</td>
        <td>становиться (стоять) на коленях</td>
    </tr>
    <tr>
        <td>know</td>
        <td>knew</td>
        <td>known</td>
        <td>знать, разбираться, иметь представление</td>
    </tr>
    <tr>
        <td>lay</td>
        <td>laid</td>
        <td>laid</td>
        <td>класть, положить, покрывать</td>
    </tr>
    <tr>
        <td>lead</td>
        <td>led</td>
        <td>led</td>
        <td>вести за собой, сопровождать, руководить</td>
    </tr>
    <tr>
        <td>leave</td>
        <td>left</td>
        <td>left</td>
        <td>покидать, уходить, уезжать, оставлять</td>
    </tr>
    <tr>
        <td>lend</td>
        <td>lent</td>
        <td>lent</td>
        <td>одалживать, давать взаймы (в долг)</td>
    </tr>
    <tr>
        <td>let</td>
        <td>let</td>
        <td>let</td>
        <td>позволять, разрешать</td>
    </tr>
    <tr>
        <td>lie</td>
        <td>lay</td>
        <td>lain</td>
        <td>лежать</td>
    </tr>
    <tr>
        <td>light</td>
        <td>lit</td>
        <td>lit</td>
        <td>защигать, светиться, освещать</td>
    </tr>
    <tr>
        <td>lose</td>
        <td>lost</td>
        <td>lost</td>
        <td>терять, лишаться, утрачивать</td>
    </tr>
    <tr>
        <td>make</td>
        <td>made</td>
        <td>made</td>
        <td>делать, создавать, изготавливать</td>
    </tr>
    <tr>
        <td>mean</td>
        <td>meant</td>
        <td>meant</td>
        <td>значить, иметь в виду, подразумевать</td>
    </tr>
    <tr>
        <td>meet</td>
        <td>met</td>
        <td>met</td>
        <td>встречать, знакомиться</td>
    </tr>
    <tr>
        <td>mistake</td>
        <td>mistook</td>
        <td>mistaken</td>
        <td>ошибаться</td>
    </tr>
    <tr>
        <td>pay</td>
        <td>paid</td>
        <td>paid</td>
        <td>платить, оплачивать, рассчитываться</td>
    </tr>
    <tr>
        <td>put</td>
        <td>put</td>
        <td>put</td>
        <td>ставить, помещать, класть</td>
    </tr>
    <tr>
        <td>read</td>
        <td>read</td>
        <td>read</td>
        <td>читать, прочитать</td>
    </tr>
    <tr>
        <td>ride</td>
        <td>rode</td>
        <td>ridden</td>
        <td>ехать верхом, кататься</td>
    </tr>
    <tr>
        <td>ring</td>
        <td>rang</td>
        <td>rung</td>
        <td>звенеть, звонить</td>
    </tr>
    <tr>
        <td>rise</td>
        <td>rose</td>
        <td>risen</td>
        <td>восходить, вставать, подниматься</td>
    </tr>
    <tr>
        <td>run</td>
        <td>ran</td>
        <td>run</td>
        <td>бежать, бегать</td>
    </tr>
    <tr>
        <td>say</td>
        <td>said</td>
        <td>said</td>
        <td>говорить, сказать, произносить</td>
    </tr>
    <tr>
        <td>see</td>
        <td>saw</td>
        <td>seen</td>
        <td>видеть</td>
    </tr>
    <tr>
        <td>seek</td>
        <td>sought</td>
        <td>sought</td>
        <td>искать, разыскивать</td>
    </tr>
    <tr>
        <td>sell</td>
        <td>sold</td>
        <td>sold</td>
        <td>продавать, торговать</td>
    </tr>
    <tr>
        <td>send</td>
        <td>sent</td>
        <td>sent</td>
        <td>посылать, отправлять, отсылать</td>
    </tr>
    <tr>
        <td>set</td>
        <td>set</td>
        <td>set</td>
        <td>устанавливать, задавать, назначать</td>
    </tr>
    <tr>
        <td>sew</td>
        <td>sewed</td>
        <td>sewn/sewed</td>
        <td>шить, пришивать</td>
    </tr>
    <tr>
        <td>shake</td>
        <td>shook</td>
        <td>shaken</td>
        <td>трясти, встряхивать</td>
    </tr>
    <tr>
        <td>shine</td>
        <td>shone</td>
        <td>shone</td>
        <td>светить, сиять, озарять</td>
    </tr>
    <tr>
        <td>shoot</td>
        <td>shot</td>
        <td>shot</td>
        <td>стрелять</td>
    </tr>
    <tr>
        <td>show</td>
        <td>showed</td>
        <td>shown</td>
        <td>показывать</td>
    </tr>
    <tr>
        <td>shrink</td>
        <td>shrank</td>
        <td>shrunk</td>
        <td>сжиматься, сокращаться</td>
    </tr>
    <tr>
        <td>shut</td>
        <td>shut</td>
        <td>shut</td>
        <td>закрывать, запирать, затворять</td>
    </tr>
    <tr>
        <td>sing</td>
        <td>sang</td>
        <td>sung</td>
        <td>петь, напевать</td>
    </tr>
    <tr>
        <td>sink</td>
        <td>sank</td>
        <td>sunk</td>
        <td>тонуть, погружаться</td>
    </tr>
    <tr>
        <td>sit</td>
        <td>sat</td>
        <td>sat</td>
        <td>сидеть, садиться</td>
    </tr>
    <tr>
        <td>sleep</td>
        <td>slept</td>
        <td>slept</td>
        <td>спать</td>
    </tr>
    <tr>
        <td>slide</td>
        <td>slid</td>
        <td>slid</td>
        <td>скользить</td>
    </tr>
    <tr>
        <td>speak</td>
        <td>spoke</td>
        <td>spoken</td>
        <td>говорить, разговаривать, высказываться</td>
    </tr>
    <tr>
        <td>spend</td>
        <td>spent</td>
        <td>spent</td>
        <td>тратить, расходовать, проводить (время)</td>
    </tr>
    <tr>
        <td>spit</td>
        <td>spat</td>
        <td>spat</td>
        <td>плевать, плеваться</td>
    </tr>
    <tr>
        <td>split</td>
        <td>split</td>
        <td>split</td>
        <td>раскалывать, расщеплять</td>
    </tr>
    <tr>
        <td>spread</td>
        <td>spread</td>
        <td>spread</td>
        <td>распространять, простираться</td>
    </tr>
    <tr>
        <td>spring</td>
        <td>sprang</td>
        <td>sprung</td>
        <td>возникнуть, вскочить</td>
    </tr>
    <tr>
        <td>stand</td>
        <td>stood</td>
        <td>stood</td>
        <td>стоять</td>
    </tr>
    <tr>
        <td>steal</td>
        <td>stole</td>
        <td>stolen</td>
        <td>воровать, красть</td>
    </tr>
    <tr>
        <td>stick</td>
        <td>stuck</td>
        <td>stuck</td>
        <td>втыкать, приклеивать</td>
    </tr>
    <tr>
        <td>sting</td>
        <td>stung</td>
        <td>stung</td>
        <td>жалить, укусить</td>
    </tr>
    <tr>
        <td>stink</td>
        <td>stank</td>
        <td>stunk</td>
        <td>вонять</td>
    </tr>
    <tr>
        <td>strike</td>
        <td>struck</td>
        <td>struck</td>
        <td>ударять, бить, поражать</td>
    </tr>
    <tr>
        <td>swear</td>
        <td>swore</td>
        <td>sworn</td>
        <td>клясться, присягать</td>
    </tr>
    <tr>
        <td>sweep</td>
        <td>swept</td>
        <td>swept</td>
        <td>мести, подметать, смахивать</td>
    </tr>
    <tr>
        <td>swim</td>
        <td>swam</td>
        <td>swum</td>
        <td>плавать, плыть</td>
    </tr>
    <tr>
        <td>swing</td>
        <td>swung</td>
        <td>swung</td>
        <td>качать, раскачивать, размахивать</td>
    </tr>
    <tr>
        <td>take</td>
        <td>took</td>
        <td>taken</td>
        <td>брать, хватать, взять</td>
    </tr>
    <tr>
        <td>teach</td>
        <td>taught</td>
        <td>taught</td>
        <td>учить, обучать</td>
    </tr>
    <tr>
        <td>tear</td>
        <td>tore</td>
        <td>torn</td>
        <td>рвать, отрывать</td>
    </tr>
    <tr>
        <td>tell</td>
        <td>told</td>
        <td>told</td>
        <td>рассказывать</td>
    </tr>
    <tr>
        <td>think</td>
        <td>thought</td>
        <td>thought</td>
        <td>думать, мыслить, размышлять</td>
    </tr>
    <tr>
        <td>throw</td>
        <td>threw</td>
        <td>thrown</td>
        <td>бросать, кидать, метать</td>
    </tr>
    <tr>
        <td>understand</td>
        <td>understood</td>
        <td>understood</td>
        <td>понимать, постигать</td>
    </tr>
    <tr>
        <td>wake</td>
        <td>woke</td>
        <td>woken</td>
        <td>просыпаться, будить</td>
    </tr>
    <tr>
        <td>wear</td>
        <td>wore</td>
        <td>worn</td>
        <td>носить (одежду)</td>
    </tr>
    <tr>
        <td>weep</td>
        <td>wept</td>
        <td>wept</td>
        <td>плакать, рыдать</td>
    </tr>
    <tr>
        <td>win</td>
        <td>won</td>
        <td>won</td>
        <td>победить, выиграть</td>
    </tr>
    <tr>
        <td>write</td>
        <td>wrote</td>
        <td>written</td>
        <td>писать, записывать</td>
    </tr>
  </table>";
    }
}
